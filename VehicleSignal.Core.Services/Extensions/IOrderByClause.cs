using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleSignal.Core.Extensions
{
    public interface IOrderByClause<T> where T : class, new()
    {
        IOrderedQueryable<T> ApplySort(IQueryable<T> query, bool firstSort);
    }
}
