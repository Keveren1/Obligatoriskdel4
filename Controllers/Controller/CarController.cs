using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Obligatoriskdel3.Controllers.Managers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class CarController : Controller
    {
        private CarManager _manager = new CarManager();
        // GET: api/Cars?modelFilter<value>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get([FromQuery] string modelFilter, [FromQuery] int? priceFilter,
            [FromQuery] string licensePlateFilter)
        {
            IEnumerable<Car> cars = _manager.GetAll(modelFilter, priceFilter, licensePlateFilter);

            if (cars.Count() <= 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(cars);
            }

        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Car car = _manager.GetById(id);
            if (car == null) return NotFound("No such item, id: " + id);
            return Ok(car);
        }

        [HttpPost]
        public Car Post([FromBody] Car newCar)
        {
            return _manager.AddCar(newCar);
        }

        [HttpDelete("{id}")]
        public Car Delete(int id)
        {
            Car car = _manager.GetById(id);
            return _manager.Delete(id);
        }
    }
}
