using MediatR;
using School.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace School.Api.Commands.DeleteSchool
{
    public class DeleteSchoolCommandHandler : IRequestHandler<DeleteSchoolCommand>
    {
        private readonly SchoolDbContext _context;

        public DeleteSchoolCommandHandler(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteSchoolCommand request, CancellationToken cancellationToken)
        {
            var school = await _context.Schools
                .FindAsync(request.RefId);

            if (school == null)
            {
                throw new Exception($"Entity \"{nameof(School)}\" ({request.RefId}) was not found.");
            }

            _context.Schools.Remove(school);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}