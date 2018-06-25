using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Stock_Management.Models.Data
{
    public class Db : DbContext
    {
        public DbSet<StockDTO> Products { get; set; }
        public DbSet<SaleDTO> Sales { get; set; }
        public DbSet<ProfitAndLossDTO> ProfitAndLoss { get; set; }
        public DbSet<CategoryDTO> categories { get; set; }
        public DbSet<UserDTO> users { get; set; }
    }
}