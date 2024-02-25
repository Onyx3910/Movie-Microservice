using Audit.Api.Models;
using Audit.Api.Models.Commands;
using Audit.Api.Models.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Audit.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuditController(IMediator mediator, ILogger<AuditController> logger) : ControllerBase
    {
        private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        private readonly ILogger<AuditController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        [HttpPost]
        [Route("Log")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateLog([FromBody] CreateLogCommand command)
        {
            _logger.LogInformation("----- Creating Log - CorrelationId: {CorrelationId}", command.CorrelationId);
            var successful = await _mediator.Send(command);
            if(!successful) return BadRequest();
            return CreatedAtAction(nameof(CreateLog), null);
        }

        [HttpGet]
        [Route("Log/{correlationId}")]
        [ProducesResponseType(typeof(List<LogEntry>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetLogsByCorrelationId(Guid correlationId)
        {
            _logger.LogInformation("----- Getting Logs - CorrelationId: {CorrelationId}", correlationId);
            var logs = await _mediator.Send(new GetLogsByCorrelationIdCommand(correlationId));
            var logEntries = logs.Select(log => new LogEntry(log.CorrelationId, ((Status)log.StatusId).ToString(), log.Message));
            if(!logs.Any()) return NotFound();
            return Ok(logEntries);
        }
    }
}
