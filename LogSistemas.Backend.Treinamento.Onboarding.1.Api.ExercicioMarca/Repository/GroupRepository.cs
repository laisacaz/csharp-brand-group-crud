using Dapper;
using Dommel;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Data;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.DTO;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Entities;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Extensions;
using static Dapper.SqlMapper;

namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Repository
{
    public class GroupRepository
    {
        private readonly PostgresConnection _conn;
        public GroupRepository(PostgresConnection conn)
        {
            _conn = conn;
        }

        public async Task<IEnumerable<Group>> GetAllAsync()
        {
            return await _conn.Get().GetAllAsync<Group>();
        }

        public async Task<Group> GetByIdAsync(int id)
        {
            return await _conn.Get().FirstOrDefaultAsync<Group>(x => x.Id == id);
        }

        public async Task<int> InsertAsync(Group group)
        {
            int id = (int)await _conn.Get().InsertAsync<Group>(group);
            return id;
        }

        public async Task<IEnumerable<GroupActivesDTO>> GetActivesAsync()
        {
            string sql = @"SELECT cod as Id, Description as descricao
                          from pro_grupo
                           where ativo = true";

            IEnumerable<GroupActivesDTO> dto = await _conn.Get().QueryAsync<GroupActivesDTO>(sql);
            return dto;
        }

        public async Task UpdateAsync(Group group)
        {
            await _conn.Get().UpdateAsync<Group>(group);
        }
        public async Task<bool> IdExists(int id)
        {
            return await _conn.Get().AnyAsync<Group>(x => x.Id == id);
        }

        public async Task<BasePagedSearchDTO<GroupPagedSearchDTO>> Search(bool active, string? description, bool? enablesubgroup, int? limit, int? offset)
        {
            string columnSearchSql = @"SELECT cod as Id, descricao as description, subgrupo as enablesubgroup from pro_grupo";
            string whereSearchSql = "where pro_grupo.ativo = @active";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("active", active, System.Data.DbType.Boolean);

            if (description.IsFill())
            {
                whereSearchSql += " and descricao ILIKE CONCAT('%', @description, '%')";
                parameters.Add("descricao", description);
            }


            whereSearchSql += " and subgrupo = @enablesubgroup";
            parameters.Add("enablesubgroup", enablesubgroup, System.Data.DbType.Boolean);




            string pagedSearchSql = @$"{columnSearchSql} {whereSearchSql} limit {limit} offset {offset}";
            string searchSql = $"select count(cod) from pro_grupo {whereSearchSql}";

            GridReader? reader = await _conn.Get().QueryMultipleAsync(
                sql: $"{pagedSearchSql}; {searchSql}",
                parameters);
            IEnumerable<GroupPagedSearchDTO> data = await reader.ReadAsync<GroupPagedSearchDTO>();
            int recordCount = await reader.ReadSingleAsync<int>();
            BasePagedSearchDTO<GroupPagedSearchDTO> dto = new BasePagedSearchDTO<GroupPagedSearchDTO>();
            dto.Data = data;
            dto.RecordCount = recordCount;

            return dto;

        }

    }
}
