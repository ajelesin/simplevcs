using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using testtask.Models.DataAccess;

namespace testtask.Models.Logic
{
    public class SimpleVcs
    {
        private readonly IDataProvider _dataProvider;

        public SimpleVcs(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public Result SaveNewChanges(string fileName, Stream fileStream)
        {
            try
            {
                byte[] fileData;
                using (var ms = new MemoryStream())
                {
                    fileStream.CopyTo(ms);
                    fileData = ms.ToArray();
                }

                var assemblyInfo = AssemblyChanges.GetAssemblyInfo(fileName, fileData);

                var historyList = _dataProvider.LoadChangesHistory(assemblyInfo.Assembly.Id);
                var newChanges = assemblyInfo.Members
                    .Except(historyList)
                    .ForEach(o => o.CommitDate = DateTime.Now)
                    .ToList();

                assemblyInfo.Members = historyList;
                assemblyInfo.Members.AddRange(newChanges);
                _dataProvider.AddAssembly(assemblyInfo);
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail("Error: " + ex);
            }
        }

        public Result<List<AssemblyItem>> LoadAssembliesHistory()
        {
            try
            {
                var assemblies = _dataProvider.LoadAssemblyHistory()
                    .ToList();
                return Result.Ok(assemblies);
            }
            catch (Exception ex)
            {
                return Result.Fail<List<AssemblyItem>>("Error: " + ex);
            }
        }

        public Result<List<AssemblyHistoryItem>> LoadChangesHistory(string guidString)
        {
            try
            {
                var guid = Guid.Parse(guidString);
                var list = _dataProvider.LoadChangesHistory(guid)
                    .OrderByDescending(o => o.CommitDate)
                    .ToList();
                return Result.Ok(list);
            }
            catch (Exception ex)
            {
                return Result.Fail<List<AssemblyHistoryItem>>("Error: " + ex);
            }
        }


    }
}