using Stock_Management.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Stock_Management.Models.ViewModels
{
    public class StockVm
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        [Required]
        public float Price { get; set; }

        public int Quantity { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public StockVm()
        {
        }

        public StockVm(StockDTO row)
        {
            this.Id = row.Id;
            this.Name = row.Name;
            this.Description = row.Description;
            this.Price = row.Price;
            this.Quantity = row.Quantity;
            this.CategoryId = row.Category.Id;
            this.CategoryName = row.Category.Categoryname;
        }
    }
}