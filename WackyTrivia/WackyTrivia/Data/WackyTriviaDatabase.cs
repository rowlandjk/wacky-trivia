using System.Collections.Generic;
using System.Linq;
using SQLite.Net;
using WackyTrivia.Model;
using Xamarin.Forms;

namespace WackyTrivia.Data
{
    public class WackyTriviaDatabase
    {
        public SQLiteConnection Database;
        static readonly object locker = new object();

        public WackyTriviaDatabase()
        {
            //establish db connection
            Database = DependencyService.Get<ISQLite>().GetConnection();
            //seed the database if it does not exist on the phone yet
            if(!TableExists<Item>(Database))
            {
                Seed();
            }
        }

        // Method to get all items from the Items table
        public IEnumerable<Item> GetItems()
        {
            lock (locker)
            {
                return (from i in Database.Table<Item>() select i).ToList();
            }
        }

        // Static function to check if a Table exists in the database
        public static bool TableExists<T> (SQLiteConnection conn)
        {
            const string cmdText = "SELECT name FROM sqlite_master WHERE "
                + "type='table' AND name=?";
            var cmd = conn.CreateCommand(cmdText, typeof(T).Name);
            return cmd.ExecuteScalar<string>() != null;
        }

        /*Manually seeds the Item database -- later iterations will source this from
        * an external server.
        */
        public void Seed()
        {
            lock (locker)
            {
                Database.CreateTable<Item>();
            }

            var item = new Item
            {
                Name = "Xbox One",
                Value = 350.00
            };
            var item2 = new Item
            {
                Name = "Super Bowl Ticket",
                Value = 4639.00
            };
            var item3 = new Item
            {
                Name = "Big Mac",
                Value = 3.99
            };
            var item4 = new Item
            {
                Name = "iPhone 6",
                Value = 549.00
            };
            var item5 = new Item
            {
                Name = "Samsung Galaxy S5",
                Value = 389.00
            };
            var item6 = new Item
            {
                Name = "Gallon of Milk",
                Value = 3.60
            };
            lock (locker)
            {
                Database.Insert(item);
                Database.Insert(item2);
                Database.Insert(item3);
                Database.Insert(item4);
                Database.Insert(item5);
                Database.Insert(item6);
            }
        }
    }
}
