using System.ComponentModel.DataAnnotations;

namespace FirstMVCProject.Dto.Company
{
	public class CreateCompanyDto
	{
		[Required(ErrorMessage = "Company Name Is required")]
		public string CompanyName { get; set; }
		[Required(ErrorMessage = "Company Email Is required")]
		public string CompanyEmail { get; set; }
		public string About { get; set; }
	}
}
