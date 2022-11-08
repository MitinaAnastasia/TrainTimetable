using System.Globalization;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using TrainTimetable.Entities.Models;
using TrainTimetable.Repository;
using Microsoft.AspNetCore.Mvc;

namespace TrainTimetable.WebAPI.Controllers
{
    /// <summary>
    /// Doctors endpoints
    /// </summary>
    [ProducesResponseType(200)]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TrainsController : ControllerBase
    {
        private IRepository<Train> _repository;

        /// <summary>
        /// Trains controller
        /// </summary>
        public TrainsController(IRepository<Train> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Get trains
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetTrains()
        {
            var train1 = new Train()
            {
                TrainNumber = "1A",
                FirstStation = "Moscow",
                LastStation = "Voronezh"
            };

            var train2 = new Train()
            {
                TrainNumber = "1B",
                FirstStation = "SPB",
                LastStation = "Kursk"
            };

            try
            {
                train1 = _repository.Save(train1);
                train2 = _repository.Save(train2);
                train1.LastStation = "Murmansk";
                train2.TrainNumber = "17AC";
                train1 = _repository.Save(train1);                
                train2 = _repository.Save(train2);
            }
            catch(Exception e)
            {

            }

            var trains = _repository.GetAll();
            return Ok(trains);
        }
    }
}