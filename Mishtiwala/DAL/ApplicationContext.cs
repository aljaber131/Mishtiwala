using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<DeliveryHistory> DeliveryHistories { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<TransactionHistory> TransactionHistories { get; set; }
        public DbSet<Sweet> Sweets { get; set; }
        public DbSet<Token> Tokens { get; set; }
    }
}
