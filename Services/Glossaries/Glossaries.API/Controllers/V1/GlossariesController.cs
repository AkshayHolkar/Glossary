using Glossaries.Application.Features.Glossaries.Commands.CreateGlossary;
using Glossaries.Application.Features.Glossaries.Commands.DeleteGlossary;
using Glossaries.Application.Features.Glossaries.Commands.UpdateGlossary;
using Glossaries.Application.Features.Glossaries.Queries.GetGlossariesList;
using Glossaries.Application.Features.Glossaries.Queries.GetGlossaryById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Glossaries.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/Glossaries")]
    public class GlossariesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GlossariesController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // Get: api/v1/Glossaries
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GlossaryDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GlossaryDto>>> GetGrossaries()
        {
            var query = new GetGlossariesListQuery();
            var Glossaries = await _mediator.Send(query);
            return Ok(Glossaries);
        }

        // Get: api/v1/Glossaries/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GlossaryDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<GlossaryDto>>> GetGrossary(int id)
        {
            var query = new GetGlossaryByIdQuery(id);
            var Glossary = await _mediator.Send(query);
            return Ok(Glossary);
        }

        // Post: api/v1/Glossaries
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> PostGlossary([FromBody] CreateGlossaryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // PUT: api/v1/Glossaries/5
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> PutGlossary([FromBody] UpdateGlossaryCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        // Delete: api/v1/Glossaries/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteGlossary(int id)
        {
            var command = new DeleteGlossaryCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
