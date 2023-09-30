using CollegeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace CollegeManagementSystem.Controllers
{
	public class SummaryController : Controller
	{
		private readonly string _connectionString;
		public SummaryController()
		{
			_connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=CollegeManagementSystem;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true";
		}

        public IActionResult SummaryDetails()
		{
			List<Summary> viewModel = new List<Summary>();

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				string sqlQuery = @"
						select course_name as Code ,
						course_desc as Name , Day ,Full_Name
						from students st full join StudentCourses sc
						on st.Id=sc.studentId full join Courses c
						on c.Id=sc.courseId
						full join schedules sh
						on c.Id= sh.CoursesID";

				using (SqlCommand command = new SqlCommand(sqlQuery, connection))
				{
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							viewModel.Add(new Summary
							{
								Code = reader["Code"].ToString(),
								Name = reader["Name"].ToString(),
								Day = reader["Day"].ToString(),
								Full_Name = reader["Full_Name"].ToString()
							});
						}
					}
				}
			}

			return View("Index", viewModel);
		}
		
	}
}
