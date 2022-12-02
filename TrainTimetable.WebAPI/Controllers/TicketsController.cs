using AutoMapper;
using TrainTimetable.Services.Abstract;
using TrainTimetable.Services.Models;
using TrainTimetable.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace TrainTimetable.Controllers
{
    /// <summary>
    /// Tickets endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService ticketService;
        private readonly IMapper mapper;

        /// <summary>
        /// Tickets controller
        /// </summary>
        public TicketsController(ITicketService ticketService, IMapper mapper)
        {
            this.ticketService = ticketService;
            this.mapper = mapper;
        }
        /// <summary>
        /// Get Tickets by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetTickets([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = ticketService.GetTickets(limit, offset);
            return Ok(mapper.Map<PageResponse<TicketResponse>>(pageModel));
        }


        /// <summary>
        /// Update Ticket
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateTicket([FromRoute] Guid id, [FromBody] UpdateTicketRequest model)
        {
            var validationResult = model.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var resultModel = ticketService.UpdateTicket(id, mapper.Map<UpdateTicketModel>(model));

                return Ok(mapper.Map<TicketPreviewResponse>(resultModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

         /// <summary>
        /// Add Ticket
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddTicket([FromQuery] Guid TimetableId, [FromQuery] Guid TrainId, [FromQuery] Guid UserId,  [FromBody] TicketModel ticket)
        {
            var response = ticketService.AddTicket(TimetableId, TrainId, UserId, ticket);
            return Ok(response);
        }


        /// <summary>
        /// Delete Ticket
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteTicket([FromRoute] Guid id)
        {
            try
            {
                ticketService.DeleteTicket(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Get Ticket
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetTicket([FromRoute] Guid id)
        {
            try
            {
                var ticketModel = ticketService.GetTicket(id);
                return Ok(mapper.Map<TicketResponse>(ticketModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}