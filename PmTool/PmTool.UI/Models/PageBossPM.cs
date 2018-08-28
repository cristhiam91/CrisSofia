using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PmTool.UI.Models
{
    public class PageBossPM
    {
        public List<Factories> Factories { get; set; }
        public List<DataCenters> DataCenters { get; set; }
        public List<Labs> Labs { get; set; }
        public List<Offices> Offices { get; set; }
        public List<OtherProjects> OtherProjects { get; set; }
    }
}