using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleSignal.Core.Extensions;
using VehicleSignal.Core.Interfaces.IServices;
using VehicleSignal.Core.Models;

namespace VehicleSignal.Core.Services
{
    public class VehicleService : IVehicleService
    {
        public IEnumerable<Vehicle> Get(PagingOption paging)
        {
            return ApplyPaging(Enumerable.Empty<Vehicle>().AsQueryable(), paging);
        }

        public Vehicle Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vehicle> GetVehiclesByCustomerId(long customerId)
        {
            throw new NotImplementedException();
        }

        public bool Update(long id)
        {
            throw new NotImplementedException();
        }



        #region Private Methods

        private IOrderByClause<Vehicle>[] GetOrderByClause(PagingOption paging)
        {
            switch (paging.SortColumn)
            {

                case "Id":
                    return new IOrderByClause<Vehicle>[] { new OrderByClause<Vehicle, long>(i => i.Id, paging.SortDirection) };
                case "VehicleIdentifier":
                    return new IOrderByClause<Vehicle>[] { new OrderByClause<Vehicle, string>(i => i.VehicleIdentifier, paging.SortDirection) };
                case "RegisterNumber":
                    return new IOrderByClause<Vehicle>[] { new OrderByClause<Vehicle, string>(i => i.RegisterNumber, paging.SortDirection) };
                case "LastSignalTime":
                    return new IOrderByClause<Vehicle>[] { new OrderByClause<Vehicle, DateTime>(i => i.LastSignalTime, paging.SortDirection) };
                default:
                    return new IOrderByClause<Vehicle>[] { new OrderByClause<Vehicle, long>(i => i.Id, paging.SortDirection) };
            }

        }


        private IEnumerable<Vehicle> ApplyPaging(IQueryable<Vehicle> query, PagingOption paging)
        {
            // Apply paging
            if (paging != null && paging.PageSize > 0 && paging.PageNumber > 0)
            {
                int pageSize = paging.PageSize;
                int pageNumber = paging.PageNumber;

                IOrderByClause<Vehicle>[] orderBy = GetOrderByClause(paging);

                // Apply sorting
                bool isFirstSort = true;
                orderBy.ToList().ForEach(by =>
                {
                    query = by.ApplySort(query, isFirstSort);
                    isFirstSort = false;
                });

                return query
                    .Skip(pageSize * (pageNumber - 1))
                    .Take(pageSize).ToList();
            }
            else
            {
                // No paging
                return query.ToList();
            }
        }
        #endregion
    }
}
