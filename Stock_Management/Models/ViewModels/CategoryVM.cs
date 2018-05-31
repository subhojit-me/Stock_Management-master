using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stock_Management.Models.ViewModels
{
    public class CategoryVM
    {
        public int CategoryId { get; set; }
        public string Categoryname { get; set; }

        public IList<StockVm> products { get; set; }
    }
}