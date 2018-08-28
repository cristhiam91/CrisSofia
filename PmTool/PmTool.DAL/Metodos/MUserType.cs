using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PmTool.DATA;
using ServiceStack.OrmLite;
using PmTool.DAL.Interfaces;


namespace PmTool.DAL.Metodos
{
    public class MUserType : MBase, IUserType
    {
        public List<UserTypes> ListUserTypes()
        {
            try
            {
                return _db.Select<UserTypes>();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
