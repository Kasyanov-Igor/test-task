using Microsoft.EntityFrameworkCore;
using Test_task.Services.Interfaces;

namespace TestTask.Services
{
    public class MySQLConnection : ADatabaseConnection
    {
        public const string _DATABASE_NAME = "DB";

        public const string USER = "user";

        public const string PASSWORD = "12345678";

        protected override string ReturnConnectionString()
        {
            return $"server=localhost;port=3300;user={USER};password={PASSWORD};database={_DATABASE_NAME}";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(this.ConnectionString, new MySqlServerVersion(new Version(8, 0, 40)));
        }
    }
}
