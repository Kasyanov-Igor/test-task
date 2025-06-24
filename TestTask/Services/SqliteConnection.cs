using Microsoft.EntityFrameworkCore;
using Test_task.Services.Interfaces;

namespace Test_task.Services
{
	public class SqliteConnection : ADatabaseConnection
	{
		public const string _DATABASE_NAME = "../DB.db";

		protected override string ReturnConnectionString()
		{
			return $"Data Source={_DATABASE_NAME}";
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite(this.ConnectionString);
		}
	}
}

