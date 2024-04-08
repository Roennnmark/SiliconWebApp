using SiliconWebApp.Models;

namespace SiliconWebApp.ViewModels;

public class CoursesViewModel
{
    public IEnumerable<CourseModel> Courses { get; set; } = [];
    public CourseModel? Course { get; set; }
}
