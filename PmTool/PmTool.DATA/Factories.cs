using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PmTool.DATA
{
    public class Factories
    {
        [AutoIncrement]
        public int Factory_request_id { get; set; }

        public int? Factory_requestor_id { get; set; }

        public int Assigned_pm { get; set; }

        public string Site_name { get; set; }

        public string Program_name { get; set; }

        public string Project_name { get; set; }

        public int? Project_phase { get; set; }

        public DateTime? Request_date { get; set; }

        public DateTime? Expected_date { get; set; }

        public double? Project_budget { get; set; }

        public int? Project_type { get; set; }

        public string Factory_name { get; set; }

        public int? Total_number_bays { get; set; }

        public int? Total_number_ports_per_bay { get; set; }

        public int? Total_number_copper_ports_per_bay { get; set; }

        public int? Total_number_fiber_ports_per_bay { get; set; }

        public int? Speed_connection { get; set; }

        public int? Fab_type { get; set; }

        public double? Square_footage { get; set; }

        public string Project_description { get; set; }

        public int? Scope { get; set; }

    }

}
