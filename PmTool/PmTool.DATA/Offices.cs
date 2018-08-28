using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace PmTool.DATA
{
    public class Offices
    {
        [AutoIncrement]
        public int Office_request_id { get; set; }

        public int? Office_requestor_id { get; set; }

        public int Assigned_pm { get; set; }

        public string Site_name { get; set; }

        public string Program_name { get; set; }

        public string Project_name { get; set; }

        public int? Project_phase { get; set; }

        public DateTime? Request_date { get; set; }

        public DateTime Expected_date { get; set; }

        public double? Project_budget { get; set; }

        public int? Project_type { get; set; }

        public int Total_number_workstations { get; set; }

        public int? Total_number_ports_per_workstation { get; set; }

        public int? Speed_connection { get; set; }

        public int? Total_number_workstation_copper_ports { get; set; }

        public int? Total_number_workstation_fiber_ports { get; set; }

        public int? Number_of_auditoriums { get; set; }

        public int? Number_of_A_type_rooms { get; set; }

        public int? Number_of_B_type_rooms { get; set; }

        public int? Number_of_C_type_rooms { get; set; }

        public int? Number_of_Collaboration_rooms { get; set; }

        public int? Number_of_phonebooths { get; set; }

        public double? Square_footage { get; set; }

        public string Project_description { get; set; }

        public int? Scope { get; set; }

        public int? Connection { get; set; }


    }
}
