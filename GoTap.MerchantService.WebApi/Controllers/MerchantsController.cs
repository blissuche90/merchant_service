using GoTap.MerchantService.Application.Features.Merchants.Commands.CreateMerchant;
using GoTap.MerchantService.Application.Features.Merchants.Commands.DeleteMerchant;
using GoTap.MerchantService.Application.Features.Merchants.Commands.UpdateMerchant;
using GoTap.MerchantService.Application.Features.Merchants.Queries.Application.Merchants.Queries;
using GoTap.MerchantService.Application.Features.Merchants.Queries.GetAllMerchants;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GoTap.MerchantService.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MerchantsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MerchantsController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create(CreateMerchantCommand command)
        {
            try
            {
                var id = await _mediator.Send(command);
                return CreatedAtAction(nameof(GetById), new { id }, new { id });
            }
            catch (FluentValidation.ValidationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var merchant = await _mediator.Send(new GetMerchantByIdQuery(id));
            if (merchant == null) return NotFound();
            return Ok(merchant);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var merchants = await _mediator.Send(new GetAllMerchantsQuery());
            return Ok(merchants);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateMerchantCommand command)
        {
            if (id != command.Id) return BadRequest("ID in URL and body must match.");
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteMerchantCommand(id));
            return NoContent();
        }

    }
}
