using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PmTool.UI.Models
{
    public class OtherProjects
    {
        [DisplayName("Request id")]
        public int Other_request_id { get; set; }
        [DisplayName("Project description")]
        public string Project_description { get; set; }
        [DisplayName("Requestor id")]
        public int? Other_requestor_id { get; set; }
        [DisplayName("Project Type")]
        public int Other_projectType { get; set; }
        [DisplayName("Assigned Pm")]
        public string Assigned_pm { get; set; }

    }
}
