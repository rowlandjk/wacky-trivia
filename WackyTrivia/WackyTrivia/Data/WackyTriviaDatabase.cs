using System.Collections.Generic;
using System.Linq;
using SQLite.Net;
using WackyTrivia;
using WackyTrivia.Model;
using Xamarin.Forms;

namespace WackyTrivia.Data
{
    public class WackyTriviaDatabase
    {
        public SQLiteConnection database;
        static object locker = new object();

        public WackyTriviaDatabase()
        {
            //establish db connection
            database = DependencyService.Get<ISQLite>().GetConnection();
            //seed the database if it does not exist on the phone yet
            if(!TableExists<Item>(database))
            {
                Seed();
            }
        }

        public IEnumerable<Item> GetItems()
        {
            lock (locker)
            {
                return (from i in database.Table<Item>() select i).ToList();
            }
        }

        public static bool TableExists<T> (SQLiteConnection conn)
        {
            const string cmdText = "SELECT name FROM sqlite_master WHERE "
                + "type='table' AND name=?";
            var cmd = conn.CreateCommand(cmdText, typeof(T).Name);
            return cmd.ExecuteScalar<string>() != null;
        }

        public void Seed()
        {
            database.CreateTable<Item>();

            var item = new Item();
            item.Name = "Xbox One";
            item.Value = 350.00;
            var item2 = new Item();
            item2.Name = "Super Bowl Ticket";
            item2.Value = 4639.00;
            var item3 = new Item();
            item3.Name = "Big Mac";
            item3.Value = 3.99;
            var item4 = new Item();
            item4.Name = "iPhone 6";
            item4.Value = 549.00;
            var item5 = new Item();
            item5.Name = "Samsung Galaxy S5";
            item5.Value = 389.00;
            var item6 = new Item();
            item6.Name = "Gallon of Milk";
            item6.Value = 3.60;
            lock (locker)
            {
                database.Insert(item);
                database.Insert(item2);
                database.Insert(item3);
                database.Insert(item4);
                database.Insert(item5);
                database.Insert(item6);
            }
        }
    }
}
