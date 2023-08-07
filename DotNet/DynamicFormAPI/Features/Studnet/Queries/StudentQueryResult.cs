//using DynamicFormAPI.Models;
//using DynamicFormAPI.Models.RequestModels;
//using DynamicFormAPI.Models.ResponseModel;
//using MediatR;
//using Microsoft.EntityFrameworkCore;

//namespace DynamicFormAPI.Features.Studnet.Queries
//{
//    public class StudentQueryResult : IRequest<ResponseDto>
//    {
//        public int StudentId { get; set; }
//        public string StudentName { get; set; }
//        public List<SubjectDto> Subjects { get; set; }

//        public class StudentQueryResultHandler : IRequestHandler<StudentQueryResult, ResponseDto>
//        {
//            private readonly sdirectdbContext _context;
//            public StudentQueryResultHandler(sdirectdbContext context)
//            {
//                _context = context;
//            }

//            public async Task<ResponseDto> Handle(StudentQueryResult request, CancellationToken cancellationToken)
//            {
//                //var student = await _context.AstitvaStudents508s.Include(s=> s.AstitvaSubjects508s).SingleOrDefaultAsync(s => s.StudentId == request.StudentId);

//                var student = (from sub in _context.AstitvaSubjects508s
//                               join stu in _context.AstitvaStudents508s on sub.StudentId equals stu.StudentId
//                               select new StudentQueryResult
//                               {
//                                   StudentId = stu.StudentId,
//                                   StudentName = stu.StudentName,
//                                   Subjects = sub.SubjectName
//                               }).ToList();

//                if (student == null)
//                {
//                    return null;
//                }
//                return student;
//            }
//        }
//    }
//}
