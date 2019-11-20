using MediatR;

namespace School.Api.Commands.UpdateSchool
{
    public class UpdateSchoolCommand: IRequest<int>
    {
        public int RefId { get; set; }

        public string SchoolCode { get; set; }

        public string SchoolName { get; set; }

        public string SchoolUrl { get; set; }

        public string SchoolAddress { get; set; }

        public string SchoolType { get; set; }

        public string SchoolPhoneNumber { get; set; }

        public string SchoolSector { get; set; }
    }
}
