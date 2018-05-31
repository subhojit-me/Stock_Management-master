using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Stock_Management.Models.Data
{
    [Table("Category")]
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Categoryname { get; set; }
        public IList<StockDTO> Products { get; set; }
    }
}