using SQLite.Net;
using Xamarin.Forms;

namespace WackyTrivia.Data
{
    public class WackyTriviaDatabase
    {
        SQLiteConnection database;
        static object locker = new object();

        public WackyTriviaDatabase()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
        }
    }
}
