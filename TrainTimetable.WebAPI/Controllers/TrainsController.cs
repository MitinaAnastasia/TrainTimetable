using AutoMapper;
using TrainTimetable.Services.Abstract;
using TrainTimetable.Services.Models;
using TrainTimetable.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace TrainTimetable.Controllers
{
    /// <summary>
    /// Trains endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TrainsController : ControllerBase
    {
        private readonly ITrainService trainService;
        private readonly IMapper mapper;

        /// <summary>
        /// Trains controller
        /// </summary>
        public TrainsController(ITrainService trainService, IMapper mapper)
        {
            this.trainService = trainService;
            this.mapper = mapper;
        }
        /// <summary>
        /// Get Trains by pages
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetTrains([FromQuery] int limit = 20, [FromQuery] int offset = 0)
        {
            var pageModel = trainService.GetTrains(limit, offset);
            return Ok(mapper.Map<PageResponse<TrainPreviewResponse>>(pageModel));
        }


        /// <summary>
        /// Add Train
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddTrain([FromBody] TrainModel train)
        {
            var response = trainService.AddTrain(train);
            return Ok(response);
        }

        /// <summary>
        /// Update Train
        /// </summary>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateTrain([FromRoute] Guid id, [FromBody] UpdateTrainRequest model)
        {
            var validationResult = model.Validate();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                var resultModel = trainService.UpdateTrain(id, mapper.Map<UpdateTrainModel>(model));

                return Ok(mapper.Map<TrainResponse>(resultModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Delete Train
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteTrain([FromRoute] Guid id)
        {
            try
            {
                trainService.DeleteTrain(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Get Train
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetTrain([FromRoute] Guid id)
        {
            try
            {
                var trainModel = trainService.GetTrain(id);
                return Ok(mapper.Map<TrainResponse>(trainModel));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}