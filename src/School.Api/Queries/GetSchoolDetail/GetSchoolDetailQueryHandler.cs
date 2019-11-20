using AutoMapper;
using MediatR;
using School.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace School.Api.Queries.GetSchoolDetail
{
    public class GetSchoolDetailQueryHandler : IRequestHandler<GetSchoolDetailQuery, GetSchoolDetailQueryResponse>
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper;

        public GetSchoolDetailQueryHandler(SchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetSchoolDetailQueryResponse> Handle(GetSchoolDetailQuery request, CancellationToken cancellationToken)
        {
            var school = await _context.Schools
                .FindAsync(request.RefId);

            if (school == null)
            {
                throw new Exception($"Entity \"{nameof(School)}\" ({request.RefId}) was not found.");
            }

            return _mapper.Map<GetSchoolDetailQueryResponse>(school);
        }
    }
}