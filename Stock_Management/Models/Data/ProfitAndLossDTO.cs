using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Stock_Management.Models.Data
{
    [Table("ProfitAndLoss")]
    public class ProfitAndLossDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string ProductName { get; set; }
        public float ProductValue { get; set; }
        public float SoldValue { get; set; }
        public float Profit { get; set; }
        public float NetProfit { get; set; }
    }
}