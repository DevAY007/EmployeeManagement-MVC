namespace FirstMVCProject.Models.Entity
{
    public class Employee : Audit
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string HomeAddress { get; set; }
        public string MaritalStatus { get; set; }
		public Guid CompanyId { get; set; }
		public CompanyRegistration Company { get; set; }



		public ICollection<EducationHistory> EducationRecords { get; set; } = new HashSet<EducationHistory>();
		public ICollection<NextOfKin> NextOfKinRecords { get; set; } = new HashSet<NextOfKin>();
        public ICollection<HealthStatus> healthStatus { get; set; } = new HashSet<HealthStatus>();

    }
}
