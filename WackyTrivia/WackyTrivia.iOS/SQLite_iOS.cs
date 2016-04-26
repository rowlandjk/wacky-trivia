using SQLite.Net;
using SQLite.Net.Platform.XamarinIOS;
using System;
using System.IO;
using WackyTrivia.Data;
using WackyTrivia.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_iOS))]

namespace WackyTrivia.iOS
{
    // ...
    public class SQLite_iOS : ISQLite
    {
        public SQLite_iOS() { }
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "restaurantdb.db";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
            var path = Path.Combine(libraryPath, sqliteFilename);
            // Create the connection
            var conn = new SQLiteConnection(new SQLitePlatformIOS(), path);
            // Return the database connection
            return conn;
        }
    }
}
