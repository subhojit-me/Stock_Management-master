using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Stock_Management.Models.Data
{
    [Table("Products")]
    public class StockDTO
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }

        public CategoryDTO Category { get; set; }
    }
}