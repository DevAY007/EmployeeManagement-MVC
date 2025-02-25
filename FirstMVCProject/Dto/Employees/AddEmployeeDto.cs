﻿using System.ComponentModel.DataAnnotations;

namespace FirstMVCProject.Dto.Employees
{
	public class AddEmployeeDto
	{
		public Guid CompanyId {get; set; }
		[Required(ErrorMessage ="FirstName Is Required")]
		public string FirstName { get; set; }
		[Required(ErrorMessage = "LastName Is Required")]
		public string LastName { get; set; }
		[Required(ErrorMessage = "DOB Is Required")]
		public string DOB { get; set; }
        [Required(ErrorMessage = "Gender Is Required")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Email Is Required")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Phone Number Is Required")]
		public string PhoneNumber { get; set; }
		[Required(ErrorMessage = "Address Is Required")]
		public string HomeAddress { get; set; }
		public string MaritalStatus { get; set; }
	}
}
