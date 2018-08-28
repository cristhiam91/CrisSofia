using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PmTool.UI.Models
{
    public class ProjectView
    {
        public int Project_id { get; set; }

        public int? Requestor_id { get; set; }

        public string Assigned_pm { get; set; }

        public string Site_name { get; set; }

        public string Program_name { get; set; }

        public string Project_name { get; set; }

        public int? Project_phase { get; set; }

        public DateTime? Request_date { get; set; }

        public DateTime? Expected_date { get; set; }

        public double? Project_budget { get; set; }

        public string Project_type { get; set; }
    }
}