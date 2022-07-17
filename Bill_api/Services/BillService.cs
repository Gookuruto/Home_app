using Bill_api.DataAccess;
using Bill_api.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bill_api.Services
{
    public class BillService
    {

        private BillDTO _billDTO { get; }

        public BillService(BillDTO billDTO)
        {
            _billDTO = billDTO;
        }

        public async Task<List<string>> GetBills()
        {
            return new List<string>() { "1", "2", "3" };
        }

        public async Task AddProvider(BillProvider provider)
        {
            await _billDTO.AddBillProvider(provider);
        }

        public async Task<List<BillProvider>> GetBillProviders()
        {
            return await _billDTO.GetBillProviders();
        }
    }
}
