using MediatR;

namespace School.Api.Commands.DeleteSchool
{
    public class DeleteSchoolCommand : IRequest
    {
        public int RefId { get; set; }
    }
}
