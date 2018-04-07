using System;
using System.Collections.Generic;
using System.Text;
using VehicleSignal.Core.Extensions;
using VehicleSignal.Core.Models;

namespace VehicleSignal.Core.Interfaces.IServices
{
    public interface IVehicleService
    {
        Vehicle Get(long id);

        IEnumerable<Vehicle> Get(PagingOption paging);

        IEnumerable<Vehicle> GetVehiclesByCustomerId(long customerId);

        bool Update(long id);


    }
}
