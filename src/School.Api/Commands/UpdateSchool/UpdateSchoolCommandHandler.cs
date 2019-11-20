using AutoMapper;
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
        private readonly IMapper _mapper;

        public UpdateSchoolCommandHandler(SchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateSchoolCommand request, CancellationToken cancellationToken)
        {
            var school = await _context.Schools
                .SingleOrDefaultAsync(c => c.RefId == request.RefId, cancellationToken);

            if (school == null)
            {
                throw new Exception($"Entity \"{nameof(School)}\" ({request.RefId}) was not found.");
            }

            _mapper.Map(request, school);

            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
