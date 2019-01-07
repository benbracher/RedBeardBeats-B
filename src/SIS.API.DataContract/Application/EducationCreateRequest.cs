using System;
using System.Collections.Generic;
using System.Text;

namespace RedStarter.API.DataContract.Application
{
    public class EducationCreateRequest
    {
        public string HighSchoolGraduationInfo { get; set; }
        public string CollegeGraduationInfo { get; set; }
        public string FieldOfStudy { get; set; }
        public bool CurrentlyEnrolled { get; set; }
    }
}
