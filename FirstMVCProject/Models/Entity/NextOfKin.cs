namespace FirstMVCProject.Models.Entity
{
	public class NextOfKin : Audit
	{
		public string FullName { get; set; }
		public string Gender { get; set; }
		public string PhoneNumber { get; set; }
		public string Gmail { get; set; }
		public string HomeAddress { get; set; }
		public Guid EmployeeId { get; set; }

		public virtual Employee Employee { get; set; }
	}
}
