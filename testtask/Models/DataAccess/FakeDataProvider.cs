using System;
using System.Collections.Generic;
using testtask.Models.Logic;

namespace testtask.Models.DataAccess
{
    public class FakeDataProvider : IDataProvider
    {
        public void AddAssembly(AssemblyInfo assemblyInfo)
        {
            // nothing to do here
        }

        public List<AssemblyHistoryItem> LoadChangesHistory(Guid guid)
        {
            return new List<AssemblyHistoryItem>
            {
                new AssemblyHistoryItem
                {
                    Author = "ME",
                    FullName = "TEST",
                    Type = MemberType.Method,
                    Description = "DESC",
                    CommitDate = DateTime.Now,
                    ChangedDate = DateTime.Now,
                },
                new AssemblyHistoryItem
                {
                    Author = "ME",
                    FullName = "TEST",
                    Type = MemberType.Method,
                    Description = "DESC",
                    CommitDate = DateTime.Now,
                    ChangedDate = DateTime.Now,
                },
                new AssemblyHistoryItem
                {
                    Author = "ME",
                    FullName = "TEST",
                    Type = MemberType.Method,
                    Description = "DESC",
                    CommitDate = DateTime.Now,
                    ChangedDate = DateTime.Now,
                },
            };
        }

        public List<AssemblyItem> LoadAssemblyHistory()
        {
            return new List<AssemblyItem>
            {
                new AssemblyItem{FileName = "TEST.dll", Id = Guid.NewGuid()},
                new AssemblyItem{FileName = "TEST1.dll", Id = Guid.NewGuid()},
                new AssemblyItem{FileName = "TEST2.dll", Id = Guid.NewGuid()},
            };
        }
    }
}