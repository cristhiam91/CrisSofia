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
    public class MPhaseType : MBase, IPhaseType
    {
        public List<PhaseTypes> ListPhaseTypes()
        {
            return _db.Select<PhaseTypes>();
        }
    }
}
