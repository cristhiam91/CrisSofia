using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PmTool.UI.Models
{
    public class Factories
    {
        [DisplayName("Request id")]
        public int Factory_request_id { get; set; }
        [DisplayName("Requestor id")]
        public int? Factory_requestor_id { get; set; }
        [DisplayName("Assigned Pm")]
        public int Assigned_pm { get; set; }
        [DisplayName("Site name")]
        public string Site_name { get; set; }
        [DisplayName("Program name")]
        public string Program_name { get; set; }
        [DisplayName("Project name")]
        public string Project_name { get; set; }
        [DisplayName("Project phase")]
        public int? Project_phase { get; set; }
        [DisplayName("Request date")]
        public DateTime? Request_date { get; set; }
        [DisplayName("Expected date")]
        public DateTime? Expected_date { get; set; }
        [DisplayName("Project budget")]
        public double? Project_budget { get; set; }
        [DisplayName("Project type")]
        public int? Project_type { get; set; }
        [DisplayName("Factory name")]
        public string Factory_name { get; set; }
        [DisplayName("Number of bays")]
        public int? Total_number_bays { get; set; }
        [DisplayName("Ports per bay")]
        public int? Total_number_ports_per_bay { get; set; }
        [DisplayName("Copper ports per bay")]
        public int? Total_number_copper_ports_per_bay { get; set; }
        [DisplayName("Fiber ports per bay")]
        public int? Total_number_fiber_ports_per_bay { get; set; }
        [DisplayName("Speed connection")]
        public int? Speed_connection { get; set; }
        [DisplayName("Factory type")]
        public int? Fab_type { get; set; }
        [DisplayName("Square footage")]
        public double? Square_footage { get; set; }
        [DisplayName("Project description")]
        public string Project_description { get; set; }
        [DisplayName("Scope")]
        public int? Scope { get; set; }

    }

}
