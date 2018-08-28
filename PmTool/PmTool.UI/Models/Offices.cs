using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PmTool.UI.Models
{
    public class Offices
    {
        [DisplayName("Request id")]
        public int Office_request_id { get; set; }
        [DisplayName("Requestor id")]
        public int? Office_requestor_id { get; set; }
        [DisplayName("Assigned Pm")]
        public string Assigned_pm { get; set; }
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
        public DateTime Expected_date { get; set; }
        [DisplayName("Project budget")]
        public double? Project_budget { get; set; }
        [DisplayName("Project type")]
        public int? Project_type { get; set; }
        [DisplayName("Number of workstations")]
        public int Total_number_workstations { get; set; }
        [DisplayName("Ports per workstations")]
        public int? Total_number_ports_per_workstation { get; set; }
        [DisplayName("Speed connection")]
        public int? Speed_connection { get; set; }
        [DisplayName("Copper ports per workstations")]
        public int? Total_number_workstation_copper_ports { get; set; }
        [DisplayName("Fiber ports per workstations")]
        public int? Total_number_workstation_fiber_ports { get; set; }
        [DisplayName("Number of auditoriums")]
        public int? Number_of_auditoriums { get; set; }
        [DisplayName("Number of A type rooms")]
        public int? Number_of_A_type_rooms { get; set; }
        [DisplayName("Number of B type rooms")]
        public int? Number_of_B_type_rooms { get; set; }
        [DisplayName("Number of C type rooms")]
        public int? Number_of_C_type_rooms { get; set; }
        [DisplayName("Number of collaboration rooms")]
        public int? Number_of_Collaboration_rooms { get; set; }
        [DisplayName("Number of phonebooths")]
        public int? Number_of_phonebooths { get; set; }
        [DisplayName("Square footage")]
        public double? Square_footage { get; set; }
        [DisplayName("Project description")]
        public string Project_description { get; set; }
        [DisplayName("Scope")]
        public int? Scope { get; set; }
        [DisplayName("Connection")]
        public int? Connection { get; set; }

    }
}
