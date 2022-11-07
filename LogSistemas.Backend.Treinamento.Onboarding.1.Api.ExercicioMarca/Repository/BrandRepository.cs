using Dapper;
using Dommel;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Data;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.DTO;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Entities;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Extensions;
using static Dapper.SqlMapper;

namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Repository
{
    public class BrandRepository
    {
        private readonly PostgresConnection _conn;
        public BrandRepository(PostgresConnection conn)
        {
            _conn = conn;
        }

        public async Task<IEnumerable<Brand>> GetAllAsync()
        {
            return await _conn.Get().GetAllAsync<Brand>();
        }

        public async Task<Brand?> GetByIdAsync(int id)
        {
            Brand? data = await _conn.Get().GetAsync<Brand>(id);
            return data;
        }

        public async Task<IEnumerable<BrandActivesDTO>> GetActivesAsync()
        {
            string sql = @"Select cod as Id, description as Description from pro_marca WHERE ativo = true";

            IEnumerable<BrandActivesDTO> dto = await _conn.Get().QueryAsync<BrandActivesDTO>(sql);
            return dto;
        }
        public async Task<int> InsertAsync(Brand brand)
        {
            int id = (int)await _conn.Get().InsertAsync<Brand>(brand);
            return id;

        }

        public async Task<BasePagedSearchDTO<BrandPagedSearchDTO>> PagedSearchAsync(bool Active, string? Description, string? MainSupplier, int? limit, int? offset)
        {
            string columnSearchSql = @"Select cod as Id,
                                     description as Description, 
                                    fornecedor_principal as MainSupplier
                                       from pro_marca";
            string whereSearchSql = "where pro_marca.Ativo = @Active";

            DynamicParameters parameters = new();
            parameters.Add("active", Active, System.Data.DbType.Boolean);
            if (Description.IsFill())
            {
                whereSearchSql += " and description ILIKE CONCAT('%', @Description, '%')";
                parameters.Add("Description", Description);
            }
            if (MainSupplier.IsFill())
            {
                whereSearchSql += " and fornecedor_principal ILIKE CONCAT('%', @MainSupplier, '%')";
                parameters.Add("MainSupplier", MainSupplier);
            }
            string pagedSearchSql = @$"{columnSearchSql} {whereSearchSql} limit {limit} offset {offset}";
            string searchSql = $"select count(cod) from pro_marca {whereSearchSql}";

            //Busca paginada
            // IEnumerable<BrandSearchDTO> dto = await _conn.Get().QueryAsync<BrandSearchDTO>(pagedSearchSql, parameters);
            //Busca sem paginar e depois contar todos os dados
            //IEnumerable<BrandSearchDTO> fullData = await _conn.Get().QueryAsync<BrandSearchDTO>(searchSql, parameters);
            //  int recordCount = fullData.Count();
            //Não é performatico pois traz todas colunas e todos registros

            GridReader? reader = await _conn.Get().QueryMultipleAsync(
                sql: $"{pagedSearchSql}; {searchSql}",
                parameters);
            IEnumerable<BrandPagedSearchDTO> data = await reader.ReadAsync<BrandPagedSearchDTO>();
            int recordCount = await reader.ReadSingleAsync<int>();
            BasePagedSearchDTO<BrandPagedSearchDTO> basePaged = new();
            basePaged.Data = data;
            basePaged.RecordCount = recordCount;


            return basePaged;

        }
        public async Task UpdateAsync(Brand brand)
        {
            await _conn.Get().UpdateAsync(brand);
        }
        public async Task<bool> IdExists(int id)
        {
            bool result = _conn.Get().Any<Brand>(x => x.Id == id);
            return result;
        }
    }
}
