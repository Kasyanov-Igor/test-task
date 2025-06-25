using System;
using Test_task.Model.Enum;

namespace Test_task.Model
{
	public class Employee
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public JobTitle JobTitle { get; set; }
		public DateTime DOB { get; set; }
	}
}
