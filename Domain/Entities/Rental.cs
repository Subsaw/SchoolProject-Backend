using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Rental
    {
        public Guid RentalId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid CarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalCost { get; set; }

        
        public Customer Customer { get; set; }
        public Car Car { get; set; }
    }

}
