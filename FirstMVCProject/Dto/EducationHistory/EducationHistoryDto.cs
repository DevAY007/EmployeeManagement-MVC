namespace FirstMVCProject.Dto.EducationHistory
{
    public class EducationHistoryDto
    {
        public Guid Id { get; set; }
        public string PrimarySchoolAttended { get; set; }
        public string SecondarySchoolAttended { get; set; }
        public string InstitutionAttended { get; set; }
        public string Qualification { get; set; }
        public string DateGraduated { get; set; }
    }
}
