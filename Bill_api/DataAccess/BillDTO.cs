using Bill_api.Database.Contexts;
using Bill_api.Database.Models;
using Microsoft.EntityFrameworkCore;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bill_api.DataAccess
{
    public class BillDTO
    {
        //TODO create repository interface for bills DTO to make mocks 
        private BillContext _billDB;

        public BillDTO(BillContext billDB)
        {
            _billDB = billDB;
        }

        public async Task<IEnumerable<Bill>> GetBills()
        {
            return await _billDB.Bills!.ToListAsync();
        }

        public async Task AddBillProvider(BillProvider billProvider)
        {
            //TODO(MP) Create bills for next period and after each pay add next period bill to
            await _billDB.AddAsync<BillProvider>(billProvider);
            var period = Period.FromDays(billProvider!.PaymentDays);
            await _billDB.AddAsync<Bill>(new Bill() { Name = billProvider.ProviderName,Amount= null,PayDate= billProvider.FirstPayment.Plus(period),Provider= billProvider });
            await _billDB.SaveChangesAsync();
        }

        public async Task<List<BillProvider>> GetBillProviders() => await _billDB.BillProviders!.ToListAsync();

        public async Task<IEnumerable<BillProvider>> GetProviderByName(string name) => await _billDB.BillProviders!
                .Where(x => x.ProviderName.ToLower() == name.ToLower())
                .ToListAsync();

        public async Task<BillProvider?> GetProviderById(int id) => await _billDB.BillProviders!.FirstOrDefaultAsync(x => x.Id == id);

        public async Task EditBillProvider(BillProvider billProvider)
        {
            var billProviderToBeEdited = await _billDB.BillProviders!.FirstOrDefaultAsync(x => x.Id == billProvider.Id);
            if(billProviderToBeEdited == null)
            {
                return;
            }
            billProviderToBeEdited.PaymentDays = billProvider.PaymentDays;
            billProviderToBeEdited.FirstPayment = billProvider.FirstPayment;
            billProviderToBeEdited.ProviderName = billProvider.ProviderName;
            await _billDB.SaveChangesAsync();
        }

        public async Task PayBill(int id, float amount)
        {
            var bill = await _billDB.Bills!.FirstOrDefaultAsync(x => x.Id == id);
            if (bill == null) return;
            bill.Amount = amount;

            await _billDB.SaveChangesAsync();

        }
    }
}
