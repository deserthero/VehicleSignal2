using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using VehicleSignal.Core.Enums;

namespace VehicleSignal.Core.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OrderByClause<T, TProperty> : IOrderByClause<T>
        where T : class, new()
    {
        /// <summary>
        /// 
        /// </summary>
        private OrderByClause()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderBy"></param>
        /// <param name="sortDirection"></param>
        public OrderByClause(Expression<Func<T, TProperty>> orderBy, SortDirection sortDirection = SortDirection.Ascending)
        {
            OrderBy = orderBy;
            SortDirection = sortDirection;
        }

        /// <summary>
        /// Order by expression
        /// </summary>
        public Expression<Func<T, TProperty>> OrderBy { get; set; }

        /// <summary>
        /// Sort direction
        /// </summary>
        public SortDirection SortDirection { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="firstSort"></param>
        /// <returns></returns>
        public IOrderedQueryable<T> ApplySort(IQueryable<T> query, bool firstSort)
        {
            if (SortDirection == SortDirection.Ascending)
            {
                if (firstSort)
                {
                    return query.OrderBy(OrderBy);
                }
                else
                {
                    return ((IOrderedQueryable<T>)query).ThenBy(OrderBy);
                }
            }
            else
            {
                if (firstSort)
                {
                    return query.OrderByDescending(OrderBy);
                }
                else
                {
                    return ((IOrderedQueryable<T>)query).ThenByDescending(OrderBy);
                }
            }
        }
    }
}
