namespace FirstMVCProject.Models.Entity
{
    public class CompanyRegistration : Audit
    {
        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }
        public string About { get; set; }
        public ICollection<Employee> employees { get; set; } = new HashSet<Employee>();
    }
}
