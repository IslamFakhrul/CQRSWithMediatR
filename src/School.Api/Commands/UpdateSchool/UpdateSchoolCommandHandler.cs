using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace School.Api.Commands.UpdateSchool
{
    public class UpdateSchoolCommandHandler : IRequestHandler<UpdateSchoolCommand, int>
    {
        private readonly SchoolDbContext _context;

        public UpdateSchoolCommandHandler(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateSchoolCommand request, CancellationToken cancellationToken)
        {
            var school = await _context.Schools
                .SingleOrDefaultAsync(c => c.RefId == request.RefId, cancellationToken);

            if (school == null)
            {
                throw new Exception($"Entity \"{nameof(School)}\" ({request.RefId}) was not found.");
            }

            school.SchoolName = request.SchoolName;
            school.SchoolCode = request.SchoolCode;
            school.SchoolUrl = request.SchoolUrl;
            school.SchoolAddress = request.SchoolAddress;
            school.SchoolType = request.SchoolType;
            school.SchoolSector = request.SchoolSector;
            school.SchoolPhoneNumber = request.SchoolPhoneNumber;

            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
