using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PmTool.UI.Models
{
    public class Labs
    {
        [DisplayName("Request id")]
        public int Lab_request_id { get; set; }
        [DisplayName("Requestor id")]
        public int? Lab_requestor_id { get; set; }
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
        [DisplayName("Budget")]
        public double? Project_budget { get; set; }
        [DisplayName("Project type")]
        public int? Project_type { get; set; }
        [DisplayName("Lab name")]
        public string Lab_name { get; set; }
        [DisplayName("Scope")]
        public int Scope { get; set; }
        [DisplayName("Square footage")]
        public double? Square_footage { get; set; }
        [DisplayName("Number of racks")]
        public int? Total_number_racks { get; set; }
        [DisplayName("Ports per rack")]
        public int? Total_number_ports_per_rack { get; set; }
        [DisplayName("Copper ports per rack")]
        public int? Total_number_copper_ports_per_racks { get; set; }
        [DisplayName("Fiber ports per rack")]
        public int? Total_number_fiber_ports_per_rack { get; set; }
        [DisplayName("Number of benches")]
        public int? Total_number_benches { get; set; }
        [DisplayName("Ports per benches")]
        public int? Total_number_ports_per_bench { get; set; }
        [DisplayName("Copper ports per bench")]
        public int? Total_number_copper_ports_per_bench { get; set; }
        [DisplayName("Fiber ports per bench")]
        public int? Total_number_fiber_ports_per_bench { get; set; }
        [DisplayName("Speed connection")]
        public int? Speed_connection { get; set; }
        [DisplayName("Project description")]
        public string Project_description { get; set; }
    }

}
