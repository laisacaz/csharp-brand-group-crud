using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.DTO;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Entities;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Payload;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.Commands.GroupCommands;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.Queries.GroupQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly IMediator _mediator;
        public GroupController(
            Serilog.ILogger logger,
            IMediator mediator)

        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Return all groups
        /// </summary>
        /// <remarks>
        /// Return inactive and active groups
        /// <para>For actives only, consume /active route</para>
        /// </remarks>
        /// <response code="200">List of groups</response>
        /// <response code="204">No Content</response>
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Group>>> GetAll()
        {
            GroupAllGroupsQuery command = new();
            IEnumerable<Group> groups = await _mediator.Send(command);
            if (groups.Any())
            {
                _logger.Information("Data returned");
                return Ok(groups);
            }
            _logger.Information("No Group Data");
            return NoContent();
        }

        /// <summary>
        /// Return a single group
        /// </summary>
        /// <param name="id">Identification of desired group</param>
        /// <response code="200">Group selected</response>
        /// <response code="404">Not found</response>
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Group>> GetById([FromRoute] int id)
        {
            GroupByIdQuery command = new(id);
            Group group = await _mediator.Send(command);
            if (group is null)
            {
                _logger.Information("No Group Data");
                return NotFound("Grupo não encontrado");
            }
            _logger.Information("Data returned");
            return Ok(group);
        }
        /// <summary>
        /// Register a new group
        /// </summary>
        /// <param name="payload">Data to be inserted</param>
        /// <response code="200">Group registered</response>
        /// <response code="400">Something went wrong</response>
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<int>> Insert(
         [FromBody] GroupInsertPayload payload)
        {
            GroupInsertCommand command = new(payload);
            int id = await _mediator.Send(command);
            _logger.Information("Group Created.");
            return Created("", id);
        }

        /// <summary>
        /// Updates a group
        /// </summary>
        /// <param name="groupId">Identification of the group to be updated</param>
        /// <param name="payload">Data to be inserted</param>
        /// <response code="200">Group updated</response>
        /// <response code="204">No Content</response>
        /// <response code="404">Not found</response>
        /// <response code="400">Something went wrong</response>
        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult> Update(
           [FromRoute(Name = "id")] int groupId,
           [FromBody] GroupUpdatePayload payload)
        {
            GroupUpdateCommand command = new(groupId, payload);
            await _mediator.Send(command);
            _logger.Information("Group updated");
            return NoContent();
        }

        /// <summary>
        /// Returns a group by its filters
        /// </summary>
        /// <param name="payload">Data to be searched</param>
        /// <response code="200">Data returned</response>
        /// <response code="204">No Content</response>
        [HttpGet]
        [Route("search")]
        public async Task<ActionResult<BasePagedSearchDTO<GroupPagedSearchDTO>>> Search(
             [FromQuery] GroupPagedSearchPayload payload)
        {
            GroupSearchQuery command = new(payload);
            BasePagedSearchDTO<GroupPagedSearchDTO> groups = await _mediator.Send(command);

            if (!groups.Data.Any())
            {
                _logger.Warning("No Group Data");
                return NoContent();
            }
            _logger.Information("Data returned");
            return Ok(groups);
        }

        /// <summary>
        /// Returns all active groups
        /// </summary>
        /// <response code="200">Data returned</response>
        /// <response code="204">No Content</response>
        [HttpGet]
        [Route("active")]
        public async Task<ActionResult<List<GroupActivesDTO>>> GetAllActives()
        {
            GroupAllActivesQuery command = new();
            IEnumerable<GroupActivesDTO> actives = await _mediator.Send(command);
            if (actives.Any())
            {
                _logger.Information("Data returned");
                return Ok(actives);
            }
            _logger.Warning("No Group Data");
            return NoContent();
        }
    }

}

