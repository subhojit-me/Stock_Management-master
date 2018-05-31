using Stock_Management.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stock_Management.Models.ViewModels
{
    public class SaleViewVM
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public float Total { get; set; }
        public DateTime date { get; set; }

        public SaleViewVM()
        {
        }

        public SaleViewVM(SaleDTO model)
        {
            this.Id = model.Id;
            this.ProductName = model.ProductName;
            this.Quantity = model.Quantity;
            this.Price = model.Price;
            this.Total = model.Total;
            this.date = model.date;
        }
    }
}