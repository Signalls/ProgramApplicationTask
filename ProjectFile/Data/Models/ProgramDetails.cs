using Data.Enum;

namespace Data.Models
{
    public class ProgramDetails
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public string Skills { get; set; }

        public string Benefits { get; set; }

        public string ApplicationCriteria { get; set; }

        public ProgramType programType { get; set; }

        public Duration ProgramDuration { get; set; }

        public MiniQualification mininmumQualification { get; set; }

        public int MaxNumberOfApplication { get; set; }
        public string Location { get; set; }
        public DateTime ProgramStart { get; set; }
        public DateTime ApplicationClose { get; set; }
        // public ApplicationTemplate ApplicationTemplate { get; set; }
        public string CoverImageUrl { get; set; }
        public PersonalInfo PersonalInformation { get; set; }
        public string PersonalInformationId { get; set; }
        public string ProgramProfileId { get; set; }

        //public AdditionalQuestion AdditionalQuestion { get; set; }
        public Mandatory Education { get; set; }
        public Mandatory Experience { get; set; }
        public Mandatory Resume { get; set; }
        public string StageName { get; set; }
        public StageType StageType { get; set; }


    }
}
