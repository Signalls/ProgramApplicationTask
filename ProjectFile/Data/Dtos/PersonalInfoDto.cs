using Data.Enum;

namespace Data.Dtos
{
    public class PersonalInfoDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Nationality { get; set; }
        public string Residence { get; set; }
        public string IdNumber { get; set; }
        public DateTime DB { get; set; }
        public Gender Gender { get; set; }
    }
}
