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
    public class MOfficeScope : MBase, IOfficeScope
    {
        public List<OfficeScopes> ListOfficeScopes()
        {
            return _db.Select<OfficeScopes>();
        }
    }
}
