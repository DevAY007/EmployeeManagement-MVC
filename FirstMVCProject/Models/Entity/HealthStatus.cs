namespace FirstMVCProject.Models.Entity
{
	public class HealthStatus :Audit
	{
		public string BloodGroup { get; set; }
		public string BloodType { get; set; }
		public string Allergies { get; set; }
		public string Precautions { get; set; }
		public string Comment { get; set; }
		public Guid EmployeeId { get; set; }

		public Employee Employee { get; set; }
	}
}
