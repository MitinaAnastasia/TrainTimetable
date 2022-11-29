using AutoMapper;
using TrainTimetable.Services.Abstract;
using TrainTimetable.Services.Models;
using TrainTimetable.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace TrainTimetable.Controllers
{
    /// <summary>
    /// Timetables endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TimetablesController : ControllerBase
    {
        private readonly ITimetableService timetableService;
        private readonly IMapper mapper;

        /// <summary>
        /// Timetables controller
        /// </summary>
        public TimetablesController(ITimetableService timetableService, IMapper mapper)
        {
            this.timetableService = timetableService;
            this.mapper = mapper;
        }
        /// <summary>
        /// Get Timetables by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetTimetables([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = timetableService.GetTimetables(limit, offset);
            return Ok(mapper.Map<PageResponse<TimetablePreviewResponse>>(pageModel));
        }


        /// <summary>
        /// Add Timetable
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddTimetable([FromBody] TimetableModel timetable)
        {
            var response = timetableService.AddTimetable(timetable);
            return Ok(response);
        }



        /// <summary>
        /// Update Timetable
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateTimetable([FromRoute] Guid id, [FromBody] UpdateTimetableRequest model)
        {
            var validationResult = model.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var resultModel = timetableService.UpdateTimetable(id, mapper.Map<UpdateTimetableModel>(model));

                return Ok(mapper.Map<TimetableResponse>(resultModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Delete Timetable
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteTimetable([FromRoute] Guid id)
        {
            try
            {
                timetableService.DeleteTimetable(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Get Timetable
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetTimetable([FromRoute] Guid id)
        {
            try
            {
                var timetableModel = timetableService.GetTimetable(id);
                return Ok(mapper.Map<TimetableResponse>(timetableModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}