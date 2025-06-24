using Microsoft.EntityFrameworkCore;
using Test_task.Model;
using Test_task.Model.Entities;

namespace Test_task.Services.Interfaces
{
	public abstract class ADatabaseConnection : DbContext
	{
		protected abstract string ReturnConnectionString();

		protected string ConnectionString { get; private set; }

		public DbSet<Counterparty> Counterpartys => Set<Counterparty>();

		public DbSet<Employee> Employees => Set<Employee>();

		public DbSet<Order> Orders => Set<Order>();

		public ADatabaseConnection()
		{
			this.ConnectionString = this.ReturnConnectionString();
			this.Database.EnsureCreated();
		}
	}
}
