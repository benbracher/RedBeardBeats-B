using System;
using System.Collections.Generic;
using System.Text;

namespace RedStarter.Business.DataContract.Application.DTOs
{
    public class EducationCreateDTO
    {
        public string HighSchoolGraduationInfo { get; set; }
        public string CollegeGraduationInfo { get; set; }
        public string FieldOfStudy { get; set; }
        public bool CurrentlyEnrolled { get; set; }
    }
}
