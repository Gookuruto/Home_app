using Bill_api.Database.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bill_api.DataAccess
{
    public class BillDTO
    {
        private BillContext _billDB;

        public BillDTO(BillContext billDB)
        {
            _billDB = billDB;
        }
    }
}
