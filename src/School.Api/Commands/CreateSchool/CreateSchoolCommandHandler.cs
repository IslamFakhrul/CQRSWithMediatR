using AutoMapper;
using MediatR;
using School.Data;
using System.Threading;
using System.Threading.Tasks;

namespace School.Api.Commands.CreateSchool
{
    public class CreateSchoolCommandHandler : IRequestHandler<CreateSchoolCommand, int>
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper;

        public CreateSchoolCommandHandler(SchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateSchoolCommand request, CancellationToken cancellationToken)
        {
            var school = _mapper.Map<Data.Entities.School>(request);

            _context.Schools.Add(school);

            await _context.SaveChangesAsync(cancellationToken);

            return school.RefId;
        }
    }
}