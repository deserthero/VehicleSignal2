using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VehicleSignal.Core.Models
{
    public class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string VehicleIdentifier { get; set; }

        public string RegisterNumber { get; set; }

        public long CustomerId { get; set; }

        public Customer Customer { get; set; } 

        public DateTime LastSignalTime { get; set; }

        public long StatusId { get; set; }
    }
}
