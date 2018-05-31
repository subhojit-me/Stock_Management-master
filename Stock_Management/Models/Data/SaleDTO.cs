using Stock_Management.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Stock_Management.Models.Data
{
    [Table("Sales")]
    public class SaleDTO
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public float Total { get; set; }
        public DateTime date { get; set;  }

    }
}