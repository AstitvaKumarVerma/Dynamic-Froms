using DynamicFormAPI.Models;
using DynamicFormAPI.Models.RequestModels;
using DynamicFormAPI.Models.ResponseModel;
using DynamicFormAPI.StaticMessages;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DynamicFormAPI.Features.Studnet.Commands
{
    public class StudentCommand : AddRequestDto, IRequest<ResponseDto>
    {
        public class StudentCommandHandler : IRequestHandler<StudentCommand, ResponseDto>
        {
            private readonly sdirectdbContext _context;
            public StudentCommandHandler(sdirectdbContext context)
            {
                _context = context;
            }

            public async Task<ResponseDto> Handle(StudentCommand request, CancellationToken cancellationToken)
            {
                ResponseDto res = new ResponseDto();


                try
                {
                    var data = _context.AstitvaStudents508s.FirstOrDefault(x => x.StudentName == request.StudentName);
                    if (data != null)
                    {
                        res.Message = Messages.postFailure;
                        res.StatusCode = Messages.failureCode;
                        return res;

                    }
                    else
                    {
                        var studendata = new AstitvaStudents508()
                        {
                            StudentName = request.StudentName,
                        };

                        _context.AstitvaStudents508s.Add(studendata);
                        _context.SaveChanges();


                        List<AstitvaSubjects508> AddResult = new List<AstitvaSubjects508>();
                        foreach (var result in request.AddStudentMarks)
                        {
                            var mrk = new AstitvaSubjects508()
                            {
                                StudentId = studendata.StudentId,
                                SubjectName = result.SubjectName,
                                Marks = result.Marks
                            };

                            AddResult.Add(mrk);
                        }

                        _context.AstitvaSubjects508s.AddRange(AddResult);
                        _context.SaveChanges();
                        res.Message = Messages.postSuccess;
                        res.StatusCode = Messages.successCode;
                        return res;
                    }
                }
                catch (Exception ex)
                {
                    res.Message = ex.Message;
                    res.StatusCode = 500;
                    return res;
                }
            }
        }
    }
}
