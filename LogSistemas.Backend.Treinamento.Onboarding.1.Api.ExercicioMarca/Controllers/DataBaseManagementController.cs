using DbUp;
using DbUp.Engine;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Consts;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataBaseManagementController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public DataBaseManagementController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> UpdateDatabase()
        {
            string connectionString = _configuration.GetConnectionString(ConnectionStrings.Postgres);
            DatabaseUpgradeResult result = DeployChanges.To
                .PostgresqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(
                assembly: Assembly.GetExecutingAssembly(),
                filter: (s) => s.Contains(value: $".Scripts.Client."))
                .JournalToPostgresqlTable("treinamento", "__migrations")
                .LogToAutodetectedLog()
                .WithTransactionPerScript()
                .Build()
                .PerformUpgrade();
            if (result.Successful)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500, result.Error);
            }
        }
        [HttpPut]
        [Route("mark-as-updated")]
        public async Task<ActionResult> MarkAsUpdatedDatabase()
        {
            string connectionString = _configuration.GetConnectionString(ConnectionStrings.Postgres);
            var result = DeployChanges.To
                .PostgresqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(
                assembly: Assembly.GetExecutingAssembly(),
               filter: (s) => s.Contains($".Scripts.Client."))
                .JournalToPostgresqlTable("treinamento", "__migrations")
                .LogToAutodetectedLog()
                .WithTransactionPerScript()
                .Build()
                .MarkAsExecuted();
            if (result.Successful)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500, result.Error);
            }
        }



    }
}
