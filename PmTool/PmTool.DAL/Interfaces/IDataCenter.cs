using PmTool.DAL.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PmTool.DATA;

namespace PmTool.DAL.Interfaces
{
    public interface IDataCenter
    {
        List<DataCenters> ListDataCenters();
        void AddDataCenter(DataCenters dataCenter);
        DataCenters SearchDataCenterProject(int dataCenterProjectId);
        void UpdateDataCenterProject(DataCenters dataCenter);
        void DeleteDataCenterProject(int dataCenterProjectId);

        List<DataCenters> SearchDataCenterProjectbypm (int user);
        List<DataCenters> SearchDataCenterByAssignedPm(int user);

    }
}
