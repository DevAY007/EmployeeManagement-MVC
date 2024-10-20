namespace FirstMVCProject.Models.Entity
{
    public class Audit
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; }
    }
}
