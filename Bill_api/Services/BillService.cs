using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bill_api.Services
{
    public class BillService
    {
        public async Task<List<string>> GetBills()
        {
            return new List<string>() { "1", "2", "3" };
        }
    }
}
