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

        public GetSchoolDetailQueryHandler(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<GetSchoolDetailQueryResponse> Handle(GetSchoolDetailQuery request, CancellationToken cancellationToken)
        {
            var school = await _context.Schools
                .FindAsync(request.RefId);

            if (school == null)
            {
                throw new Exception($"Entity \"{nameof(School)}\" ({request.RefId}) was not found.");
            }

            return new GetSchoolDetailQueryResponse
            {
                RefId = school.RefId,
                SchoolName = school.SchoolName,
                SchoolCode = school.SchoolCode,
                SchoolAddress = school.SchoolAddress,
                SchoolUrl = school.SchoolUrl,
                SchoolType = school.SchoolType,
                SchoolSector = school.SchoolSector,
                SchoolPhoneNumber = school.SchoolPhoneNumber
            };
        }
    }
}