using NodaTime;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bill_api.Database.Models
{
    public class Bill
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public float? Amount { get; set; }
        public LocalDate? PayDate { get; set; } 
        public BillProvider Provider { get; set; }
    }
}
