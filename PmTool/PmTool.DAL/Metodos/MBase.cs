using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PmTool.DAL.Metodos
{
   public class MBase
    {
        public OrmLiteConnectionFactory _conexion;
        public IDbConnection _db;

        public MBase()
        {
            _conexion = new OrmLiteConnectionFactory(BD.Default.conexion,
                SqlServerDialect.Provider);
            _db = _conexion.Open();
        }
    }
}
