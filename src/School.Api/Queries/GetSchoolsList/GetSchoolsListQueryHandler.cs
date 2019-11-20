using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Data;
using System.Threading;
using System.Threading.Tasks;

namespace School.Api.Queries.GetSchoolsList
{
    public class GetSchoolsListQueryHandler : IRequestHandler<GetSchoolsListQuery, GetSchoolsListQueryResponse>
    {
        private readonly SchoolDbContext _context;

        public GetSchoolsListQueryHandler(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<GetSchoolsListQueryResponse> Handle(GetSchoolsListQuery request, CancellationToken cancellationToken)
        {
            var schools = await _context.Schools
                .ToListAsync(cancellationToken);

            return new GetSchoolsListQueryResponse
            {
                Schools = schools
            };
        }
    }
}