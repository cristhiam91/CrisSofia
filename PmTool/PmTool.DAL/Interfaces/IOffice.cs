using PmTool.DAL.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PmTool.DATA;


namespace PmTool.DAL.Interfaces
{
    public interface IOffice
    {
        List<Offices> ListOfficeProjects();
        void AddOfficeProject(Offices office);
        Offices SearchOfficeProject(int officeProjectId);
        void UpdateOfficeProject(Offices office);
        void DeleteOfficeProject(int officeProjectId);
        List<Offices> SearchOfficeProjectbypm(int user);

        List<Offices> SearchOfficeProjectByAssignedPm(int user);

    }
}
