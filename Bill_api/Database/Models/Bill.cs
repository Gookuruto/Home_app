using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bill_api.Database.Models
{
    public class Bill
    {
        public int BillId { get; set; }
        public string? Name { get; set; }
        public float? Amount { get; set; }
        public DateOnly? PayDate { get; set; } 
    }
}
