using System.Collections.Generic;

namespace School.Api.Queries.GetSchoolsList
{
    public class GetSchoolsListQueryResponse
    {
        public IList<Data.Entities.School> Schools { get; set; }
    }
}
