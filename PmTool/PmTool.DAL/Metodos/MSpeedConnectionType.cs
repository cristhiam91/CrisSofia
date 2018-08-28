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
    public class MSpeedConnectionType : MBase, ISpeedConnectionType
    {
        public List<SpeedConnectionTypes> ListSpeedConnectionTypes()
        {
            return _db.Select<SpeedConnectionTypes>();
        }
    }
}
