using System;
using System.Collections.Generic;

namespace testtask.Models.Logic
{
    public class AssemblyItem
    {
        public List<AssemblyHistoryItem> AssemblyHistoryItems { get; set; } 

        public Guid Id { get; set; }
        public string FileName { get; set; }

        protected bool Equals(AssemblyItem other)
        {
            return Id.Equals(other.Id)
                && string.Equals(FileName, other.FileName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AssemblyItem) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Id.GetHashCode()*397) ^ (FileName != null ? FileName.GetHashCode() : 0);
            }
        }
    }
}