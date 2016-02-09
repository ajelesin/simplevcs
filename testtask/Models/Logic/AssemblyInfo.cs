using System.Collections.Generic;

namespace testtask.Models.Logic
{
    public class AssemblyInfo
    {
        public AssemblyItem Assembly { get; set; }
        public List<AssemblyHistoryItem> Members { get; set; } 
    }
}