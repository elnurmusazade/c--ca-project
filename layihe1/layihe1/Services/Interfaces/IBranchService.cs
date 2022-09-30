using layihe1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace layihe1.Services.Interfaces
{
    public interface IBranchService: IBankService<Branch>
    {
        public void HireEmployee();
        public void GetProfit();
        public void TransferMoney();
        public void TransferEmployee();
    }
}
