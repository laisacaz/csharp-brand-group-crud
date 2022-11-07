using Dommel;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.DTO;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Entities;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Payload;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.CommandHandlers;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.Commands;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.Commands.BrandCommands;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.Queries;
using LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Services.Queries.BrandQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LogSistemas.Backend.Treinamento.Onboarding._1.Api.ExercicioMarca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly IMediator _mediator;
        public BrandController(
            Serilog.ILogger logger,
             IMediator mediator
            ) //brand controller constructor 

        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Return all brands
        /// </summary>
        /// <remarks>
        /// Return inactive and active brands
        /// <para>For actives only, consume /active route</para>
        /// </remarks>
        /// <response code="200">List of brands</response>
        /// <response code="204">No Content</response>
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Brand>>> GetAll()
        {
            BrandAllBrandsQuery command = new();
            IEnumerable<Brand> brandslist = await _mediator.Send(command);

            if (brandslist.Any())
            {
                _logger.Information("Data returned");
                return Ok(brandslist);
            }
            _logger.Warning("No Brand Data");

            return NoContent();
        }

        /// <summary>
        /// Return a single brand
        /// </summary>
        /// <param name="id">Identification of desired brand</param>
        /// <response code="200">Brand selected</response>
        /// <response code="404">Not found</response>

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Brand>> GetById([FromRoute] int id)
        {
            BrandByIdQuery command = new(id);
            Brand brand = await _mediator.Send(command);

            if (brand is null)
            {
                _logger.Warning("No Brand Data");
                return NotFound("Marca não encontrada");
            }
            _logger.Information("Data returned");
            return Ok(brand);
        }

        /// <summary>
        /// Return all active brands
        /// </summary>
        /// <response code="200">List of brands</response>
        /// <response code="204">No Content</response>
        [HttpGet]
        [Route("active")]
        public async Task<ActionResult<List<BrandActivesDTO>>> GettAllActives()
        {
            BrandAllActivesQuery command = new();
            IEnumerable<BrandActivesDTO> dto = await _mediator.Send(command);


            if (!dto.Any())
            {
                _logger.Warning("No Brand Data");
                return NoContent();
            }
            _logger.Information("Data returned");
            return Ok(dto);
        }

        /// <summary>
        /// Register a new brand
        /// </summary>
        /// <param name="payload">Data to be inserted</param>
        /// <response code="200">Brand registered</response>
        /// <response code="400">Something went wrong</response>
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<int>> Insert(
            [FromBody] BrandInsertPayload payload)
        {
            BrandInsertCommand command = new(payload);
            int id = await _mediator.Send(command);

            _logger.Information("Brand Created.");
            return Created("", id);

        }

        /// <summary>
        /// Paged search, returns brands according to its filters
        /// </summary>
        /// <param name="payload"></param>
        /// <response code="200">List of brands</response>
        /// <response code="204">No Content</response>
        [HttpGet]
        [Route("search")]
        public async Task<ActionResult<BasePagedSearchDTO<BrandPagedSearchDTO>>> Search(
            [FromQuery] BrandPagedSearchPayload payload)
        {
            BrandSearchQuery command = new(payload);
            BasePagedSearchDTO<BrandPagedSearchDTO> dto = await _mediator.Send(command);
            if (!dto.Data.Any())
            {
                _logger.Warning("No Brand Data");
                return NoContent();
            }
            _logger.Information("Data returned");
            return Ok(dto);
        }

        /// <summary>
        /// Update only a brand
        /// </summary>
        /// <param name="brandId">Identification of desired brand to be updated</param>
        /// <param name="payload">Data to be updated </param>
        /// <response code="204">Brand updated</response>
        /// <response code="400">Something went wrong</response>
        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult> Update(
            [FromRoute(Name = "id")] int brandId,
            [FromBody] BrandUpdatePayload payload)
        {
            BrandUpdateCommand command = new(brandId, payload);
            await _mediator.Send(command);
            _logger.Information("Brand updated");
            return NoContent();
        }


    }
}