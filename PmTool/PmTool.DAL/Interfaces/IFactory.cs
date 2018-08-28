using PmTool.DAL.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PmTool.DATA;

namespace PmTool.DAL.Interfaces
{
    public interface IFactory
    {
        List<Factories> ListFactories();
        void AddFactory(Factories factory);
        Factories SearchFactoryProject(int factoryProjectId);
        void UpdateFactoryProject(Factories factory);
        void DeleteFactoryProject(int factoryProjectId);
        List<Factories> SearchFactoryProjectbypm(int user);
        List<Factories> SearchFactoryByAssignedPm(int user);
    }
}
