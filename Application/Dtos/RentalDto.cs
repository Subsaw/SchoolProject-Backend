using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class RentalDto
    {
        public Guid RentalId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid CarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalCost { get; set; }

        
        public CustomerDto Customer { get; set; }
        public CarDto Car { get; set; }
    }

}
