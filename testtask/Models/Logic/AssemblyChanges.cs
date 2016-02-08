using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using AnnotationLib;

namespace testtask.Models.BusinessLogic
{
    public class AssemblyChanges
    {
        public static AssemblyInfo GetAssemblyInfo(string fileName, byte[] fileData)
        {
            var assembly = Assembly.Load(fileData);
            var guid = GetItsGuid(assembly);
            var list = GetTypesAndMethodsWithChangedAttribute(assembly);

            return new AssemblyInfo
            {
                Assembly = new AssemblyItem {FileName = fileName, Id = Guid.Parse(guid), },
                Members = list
            };
        }
        
        private static string GetItsGuid(Assembly assembly)
        {
            var attribute = (GuidAttribute)assembly.GetCustomAttributes(typeof(GuidAttribute), true)[0];
            var id = attribute.Value;
            return id;
        }

        private static List<AssemblyHistoryItem> GetTypesAndMethodsWithChangedAttribute(Assembly assembly)
        {
            var result = new List<AssemblyHistoryItem>();

            foreach (var type in assembly.GetTypes())
            {
                var classAttributes = type.GetCustomAttributes(true);
                result.AddRange(classAttributes
                    .OfType<ChangedAttribute>()
                    .Select(changeAttr => new AssemblyHistoryItem
                    {
                        Author = changeAttr.Author,
                        ChangedDate = changeAttr.ChangeDate,
                        Description = changeAttr.Description,
                        FullName = type.FullName,
                        Type = MemberType.Class
                    }));

                foreach (var methodInfo in type.GetMethods())
                {
                    var methodAttributes = methodInfo.GetCustomAttributes(true);
                    result.AddRange(methodAttributes
                        .OfType<ChangedAttribute>()
                        .Select(changeAttr => new AssemblyHistoryItem
                        {
                            Author = changeAttr.Author,
                            ChangedDate = changeAttr.ChangeDate,
                            Description = changeAttr.Description,
                            Type = MemberType.Method,
                            FullName = string.Format("{0}.{1}", type.FullName, methodInfo.Name)
                        }));
                }
            }

            return result;
        }
    }
}