namespace FirstMVCProject.Models.Entity
{
	public class EducationHistory : Audit
	{
		public string PrimarySchoolAttended { get; set; }
		public string SecondarySchoolAttended { get; set; }
		public string InstitutionAttended { get; set; }
		public string Qualification { get; set; }
		public string DateGraduated { get; set; }
		public Guid EmployeeId { get; set; }

		public Employee Employee { get; set; }
	}
}
