using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Consts;
using Npgsql;

namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Data
{
    public class PostgresConnection
    {
        private readonly NpgsqlConnection _conn;
        public PostgresConnection(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString(ConnectionStrings.Postgres);

            _conn = new NpgsqlConnection(connectionString);

        }
        public NpgsqlConnection Get() => _conn;

    }
}
