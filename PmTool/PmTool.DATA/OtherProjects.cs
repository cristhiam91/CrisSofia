using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PmTool.DATA
{
    public class OtherProjects
    {
        [AutoIncrement]
        public int Other_request_id { get; set; }

        public string Project_description { get; set; }

        public int? Other_requestor_id { get; set; }

        public int Other_projectType { get; set; }

        public int Assigned_pm { get; set; }

    }
}
