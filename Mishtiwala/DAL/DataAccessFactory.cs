using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepository<User> UserData() {return new UserRepository();}

        public static IRepository<Area> AreaData() { return new AreaRepository();}

        public static IRepository<Category> CategoryData() { return new CategoryRepository();}

        public static IRepository<DeliveryHistory> DeliveryHistoryData() { return new DeliveryHistoryRepository();}

        public static IRepository<Offer> OfferData() { return new OfferRepository();}

        public static IRepository<Payment> PaymentData() { return new PaymentRepository();} 

        public static IRepository<Sweet> SweetData() { return new SweetRepository();}   

        public static IRepository<TransactionHistory> TransactionHistoryData() { return new TransactionHistoryRepository();}
    }
}
