using System;

namespace Test_task.Model.Entities
{
	public class Order
	{
		public int Id { get; set; }
		public DateTime dateTime { get; set; }
		public uint Amount { get; set; }
		public int EmployeeId { get; set; }
		public int CounterpartyId { get; set; }
	}
}
