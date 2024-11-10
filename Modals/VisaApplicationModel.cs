using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VisaApplication.Modals
{
    public class VisaApplicationModel
    {
        public int ApplicationID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string PassportCopy { get; set; }
        public string VisaType { get; set; }
        public string CountryOfApplication { get; set; }
        public string ApplicationStatus { get; set; }
        public DateTime SubmissionDate { get; set; }
    }
}