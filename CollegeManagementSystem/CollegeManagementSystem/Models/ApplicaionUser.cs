using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CollegeManagementSystem.Models
{
	public class ApplicaionUser : IdentityUser
	{
		[Required(ErrorMessage = "Please Enter Your First Name!")]
		[DisplayName("First Name")]
		[MinLength(2, ErrorMessage = "First Name must be greate than 2 characters")]
		[MaxLength(50, ErrorMessage = "First Name must be less than 50 characters")]

		public string first_Name { get; set; }
		[Required(ErrorMessage = "Please Enter Your Last Name!")]
		[DisplayName("Last Name")]
		[MinLength(2, ErrorMessage = "First Name must be greate than 2 characters")]
		[MaxLength(50, ErrorMessage = "First Name must be less than 50 characters")]
		public string last_Name { get; set; }
		
	}
}
