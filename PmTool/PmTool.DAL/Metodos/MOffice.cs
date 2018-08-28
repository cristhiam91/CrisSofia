using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PmTool.DATA;
using PmTool.DAL.Interfaces;
using ServiceStack.OrmLite;

namespace PmTool.DAL.Metodos
{
    public class MOffice : MBase, IOffice
    {
        public void AddOfficeProject(Offices office)
        {
            _db.Insert(office);
        }

        public void DeleteOfficeProject(int officeProjectId)
        {
            _db.Delete<Offices>(x => x.Office_request_id == officeProjectId);
        }

        public List<Offices> ListOfficeProjects()
        {
            return _db.Select<Offices>();
        }

        public Offices SearchOfficeProject(int officeProjectId)
        {
            return _db.Select<Offices>(x => x.Office_request_id == officeProjectId).FirstOrDefault();
        }

        public List<Offices> SearchOfficeProjectByAssignedPm(int user)
        {
            return _db.Select<Offices>(x => x.Assigned_pm == user);
        }

        public List<Offices> SearchOfficeProjectbypm(int user)
        {
            return _db.Select<Offices>(x => x.Office_requestor_id == user);
        }

        public void UpdateOfficeProject(Offices office)
        {
            _db.Update(office);
        }
    }
}
