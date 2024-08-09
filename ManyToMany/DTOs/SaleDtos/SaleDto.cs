using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyToMany.DTOs.SaleDtos
{
    public class SaleDto
    {
        public int CustomerId { get; set; }
        public int BookId { get; set; }
        public int Count { get; set; }
    }
}
