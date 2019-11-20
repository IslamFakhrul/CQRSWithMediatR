using AutoMapper;
using School.Api.Commands.CreateSchool;
using School.Api.Commands.UpdateSchool;
using School.Api.Queries.GetSchoolDetail;

namespace School.Api.AutoMapperProfiles
{
    public class SchoolProfile : Profile
    {
        public SchoolProfile()
        {
            CreateMap<CreateSchoolCommand, Data.Entities.School>()
                .IgnoreMember(dest => dest.RefId);

            CreateMap<UpdateSchoolCommand, Data.Entities.School>()
                .IgnoreMember(dest => dest.RefId);

            CreateMap<Data.Entities.School, GetSchoolDetailQueryResponse>(MemberList.Source);
        }
    }
}
