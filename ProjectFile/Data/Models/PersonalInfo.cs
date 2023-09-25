using Data.Enum;

namespace Data.Models
{
    public class PersonalInfo
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
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
