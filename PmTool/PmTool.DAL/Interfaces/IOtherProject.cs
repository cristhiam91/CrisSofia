using PmTool.DAL.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PmTool.DATA;

namespace PmTool.DAL.Interfaces
{
    public interface IOtherProject
    {
        List<OtherProjects> ListOtherProjects();
        void AddOtherProject(OtherProjects otherProject);
        OtherProjects SearchOtherProject(int OtherProjectId);
        void UpdateOtherProject(OtherProjects otherProject);
        void DeleteOtherProject(int OtherProjectId);
        List<OtherProjects> SearchOtherProjectbypm(int user);

        List<OtherProjects> SearchOtherProjectByAssignedPm(int user);
    }
}
