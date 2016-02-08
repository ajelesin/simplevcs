using System;
using System.Collections.Generic;
using testtask.Models.BusinessLogic;

namespace testtask.Models.DataAccess
{
    public interface IDataProvider
    {
        void AddAssembly(AssemblyInfo assemblyInfo);
        List<AssemblyHistoryItem> LoadChangesHistory(Guid guid);
        List<AssemblyItem> LoadAssemblyHistory();
    }
}