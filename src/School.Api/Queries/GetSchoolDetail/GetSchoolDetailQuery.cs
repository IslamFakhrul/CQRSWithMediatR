using MediatR;

namespace School.Api.Queries.GetSchoolDetail
{
    public class GetSchoolDetailQuery : IRequest<GetSchoolDetailQueryResponse>
    {
        public int RefId { get; set; }
    }
}
