using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auspex.TripService.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public Location StartLocation { get; set; }

        public Location EndLocation { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int StartMileage { get; set; }

        public int EndMileage { get; set; }

        public Car Car { get; set; }

        public int ExtraDistance { get; set; }

        public string Remarks { get; set; }

        public TripType TripType { get; set; }
    }
}