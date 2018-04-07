using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehicleSignal.Core.Extensions;
using VehicleSignal.Core.Interfaces.IServices;
using VehicleSignal.Core.Models;

namespace VehicleSignal.Web.API.Controllers
{
    [Route("api/Vehicle")]
    public class VehicleController : Controller
    {
        IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Vehicle> Get()
        {
            return _vehicleService.Get(null);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
