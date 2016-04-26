using SQLite.Net;

namespace WackyTrivia.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
