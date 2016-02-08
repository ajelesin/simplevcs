using System.Collections.Generic;

namespace testtask.Models.BusinessLogic
{
    public class AssemblyInfo
    {
        public AssemblyItem Assembly { get; set; }
        public List<AssemblyHistoryItem> Members { get; set; } 
    }
}