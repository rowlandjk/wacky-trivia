using Xamarin.Forms;
using System.IO;
using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;
using WackyTrivia.Data;
using WackyTrivia.Droid;

[assembly: Dependency(typeof(SQLite_Android))]

namespace WackyTrivia.Droid
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android() { }
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "restaurantdb.db";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            // Create the connection
            var conn = new SQLiteConnection(new SQLitePlatformAndroid(), path);
            // Return the database connection
            return conn;
        }
    }
}