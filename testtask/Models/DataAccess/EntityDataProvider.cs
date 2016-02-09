using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using testtask.Models.Logic;

namespace testtask.Models.DataAccess
{
    public class EntityDataProvider : IDataProvider
    {
        public void AddAssembly(AssemblyInfo assemblyInfo)
        {
            using (var context = new EntityContext())
            {
                if (!(context.AssemblyItems.Any(o => o.Id == assemblyInfo.Assembly.Id)))
                {
                    context.AssemblyItems.Add(assemblyInfo.Assembly);
                }
                else
                {
                    context.AssemblyItems.Attach(assemblyInfo.Assembly);
                    context.Entry(assemblyInfo.Assembly).State = EntityState.Modified;
                }

                foreach (var historyItem in assemblyInfo.Members)
                {
                    historyItem.AssemblyItem = assemblyInfo.Assembly;
                    if (!(context.AssemblyHistoryItems.Any(o => o.Id == historyItem.Id)))
                    {
                        context.AssemblyHistoryItems.Add(historyItem);
                    }
                    else
                    {
                        context.AssemblyHistoryItems.Attach(historyItem);
                        context.Entry(historyItem).State = EntityState.Modified;
                    }
                }

                context.SaveChanges();
            }
        }

        public List<AssemblyHistoryItem> LoadChangesHistory(Guid guid)
        {
            using (var context = new EntityContext())
            {
                return context.AssemblyHistoryItems
                    .Where(o => o.AssemblyItem.Id == guid)
                    .ToList();
            }
        }

        public List<AssemblyItem> LoadAssemblyHistory()
        {
            using (var context = new EntityContext())
            {
                return context.AssemblyItems.ToList();
            }
        }
    }
}