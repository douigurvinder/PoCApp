using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoCApp.Client.Entities
{
  public  class IndividualVW
    {
        public int IndividualId { get; set; }

        public string Name { get; set; }

        public DateTime DoB { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int? EducationId { get; set; }

        public string EducationText { get; set; }

        public int? CountryId { get; set; }

        public string CountryText { get; set; }

        public int? WorkExperience { get; set; }

        public Guid IndividualGuid { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

    }
}
