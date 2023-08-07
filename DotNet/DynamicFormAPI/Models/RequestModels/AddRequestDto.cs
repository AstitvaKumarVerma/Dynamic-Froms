using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DynamicFormAPI.Models.RequestModels
{
    public class AddRequestDto
    {
        [Required(ErrorMessage = "StudentName is Required")]
        public string StudentName { get; set; } = null!;
        public List<SubjectDto> AddStudentMarks { get; set; } = new List<SubjectDto>();
    }
}
