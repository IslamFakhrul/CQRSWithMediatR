using MediatR;
using School.Data;
using System.Threading;
using System.Threading.Tasks;

namespace School.Api.Commands.CreateSchool
{
    public class CreateSchoolCommandHandler : IRequestHandler<CreateSchoolCommand, int>
    {
        private readonly SchoolDbContext _context;

        public CreateSchoolCommandHandler(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateSchoolCommand request, CancellationToken cancellationToken)
        {
            var school = new Data.Entities.School
            {
                SchoolName = request.SchoolName,
                SchoolCode = request.SchoolCode,
                SchoolUrl = request.SchoolUrl,
                SchoolAddress = request.SchoolAddress,
                SchoolType = request.SchoolType,
                SchoolSector = request.SchoolSector,
                SchoolPhoneNumber = request.SchoolPhoneNumber
            };

            _context.Schools.Add(school);

            await _context.SaveChangesAsync(cancellationToken);

            return school.RefId;
        }
    }
}