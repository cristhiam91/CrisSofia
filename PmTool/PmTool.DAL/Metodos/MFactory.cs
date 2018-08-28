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
    public class MFactory : MBase, IFactory
    {
        public void AddFactory(Factories factory)
        {
            _db.Insert(factory);
        }

        public void DeleteFactoryProject(int factoryProjectId)
        {
            _db.Delete<Factories>(x => x.Factory_request_id == factoryProjectId);
        }

        public List<Factories> ListFactories()
        {
            return _db.Select<Factories>();
        }

        public Factories SearchFactoryProject(int factoryProjectId)
        {
            return _db.Select<Factories>(x => x.Factory_request_id == factoryProjectId).FirstOrDefault();
        }

        public List<Factories> SearchFactoryProjectbypm(int user)
        {
            return _db.Select<Factories>(x => x.Factory_requestor_id == user);
        }

        public List<Factories> SearchFactoryByAssignedPm(int user)
        {
            return _db.Select<Factories>(x => x.Assigned_pm == user);
        }

        public void UpdateFactoryProject(Factories factory)
        {
            _db.Update(factory);
        }
    }
}
