using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace College_Management_System.Models
{
    public class Schedules
    {
        [Key]
        public int Id { get; set; }
        public string Day { get; set;}
        [DisplayName("From")]
        public string time_start { get; set; }
        [DisplayName("To")]
        public string time_end { get; set; }
		[DisplayName("Course")]
		public int? CoursesID { get; set; }
        public Courses? Courses { get; set; }
    }
}
