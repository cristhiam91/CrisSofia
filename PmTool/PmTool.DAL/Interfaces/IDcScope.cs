using PmTool.DAL.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PmTool.DATA;


namespace PmTool.DAL.Interfaces
{
    public interface IDcScope
    {
        List<DcScopes> ListDataCenterScopes();
    }
}
