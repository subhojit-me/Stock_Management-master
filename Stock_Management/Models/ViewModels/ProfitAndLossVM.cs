using Stock_Management.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stock_Management.Models.ViewModels
{
    public class ProfitAndLossVM
    {
        public DateTime Date { get; set; }
        public string ProductName { get; set; }
        public float ProductValue { get; set; }
        public float SoldValue { get; set; }
        public float Profit { get; set; }
        public float NetProfit { get; set; }

        public ProfitAndLossVM()
        {
        }

        public ProfitAndLossVM(ProfitAndLossDTO model)
        {
            Date = model.Date;
            ProductName = model.ProductName;
            ProductValue = model.ProductValue;
            SoldValue = model.SoldValue;
            Profit = model.Profit;
            NetProfit = model.NetProfit;
        }
    }
}