using System;
using System.Collections.Generic;
using System.Text;
using VehicleSignal.Core.Enums;

namespace VehicleSignal.Core.Extensions
{
    public class PagingOption
    {
        public PagingOption()
        {
            // Set default values
            PageNumber = 1;
            PageSize = 10;
            SortColumn = string.Empty;
            SortDirection = SortDirection.Ascending;
        }

        /// <summary>
        /// The position of the page
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// The size of the pager
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Name of the database column for order by
        /// </summary>
        public string SortColumn { get; set; }

        /// <summary>
        /// Sort ascending or descending
        /// </summary>
        public SortDirection SortDirection { get; set; }
    }
}
