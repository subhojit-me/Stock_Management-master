using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stock_Management.Models.ViewModels
{
    public class CreatesaleVM
    {
        public int SelingProductId { get; set; }
        public string SelingProductName { get; set; }
        public int SelingProductPrice { get; set; }
        public int SelingProductQuantity { get; set; }
        public int Total { get; set; }
        public DateTime date { get; set; }
    }
}