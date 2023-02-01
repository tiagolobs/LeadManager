using Application.Leads.Commands.UpdateLead;
using Application.Leads.GetLeads;
using Application.Leads.Querys.GetLeads;
using Domain.Leads;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeadsController : Controller
    {
        private readonly IMediator _mediator;

        public LeadsController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        /// <summary>
        /// Get all leads.
        /// </summary>
        [Route("")]
        [HttpGet]
        [ProducesResponseType(typeof(List<LeadDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetLeds([FromQuery] LeadStatus? status)
        {
            var leads = await _mediator.Send(new GetLeadsQuery(status));

            return Ok(leads);
        }

        /// <summary>
        /// Update Lead.
        /// </summary>
        [Route("{id}")]
        [HttpPatch]
        [ProducesResponseType(typeof(List<LeadDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateLead([FromRoute] int id,
            [FromBody] UpdateLeadRequest request)
        {
            var lead = await _mediator.Send(new UpdateLeadCommand(id, request));

            return Ok(lead);
        }
    }
}