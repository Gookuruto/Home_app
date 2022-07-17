using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bill_api.Database.Models
{
    public class BillProvider
    {
        public int Id { get; set; }
        public string ProviderName { get; set; }
        public int PaymentDays { get; set; }
        public LocalDate FirstPayment { get; set; }

        public BillProvider(string providerName, int paymentDays, LocalDate firstPayment)
        {
            ProviderName = providerName;
            PaymentDays = paymentDays;
            FirstPayment = firstPayment;
        }
    }
}
