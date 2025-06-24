namespace Test_task.Model.Entities
{
	public class Counterparty
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string INN { get; set; }
		public Employee Curator { get; set; }
	}
}
