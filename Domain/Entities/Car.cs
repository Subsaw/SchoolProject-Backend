using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Car
    {
        public Guid CarId { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string LicensePlate { get; set; }
        public decimal DailyRate { get; set; }
        public string Status { get; set; } 

        
        public List<Rental> Rentals { get; set; }
    }


}
