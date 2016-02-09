using System;

namespace testtask.Models.Logic
{
    public class AssemblyHistoryItem
    {
        public int Id { get; set; }
        public Guid? AssemblyItemId { get; set; }
        public AssemblyItem AssemblyItem { get; set; }

        public string FullName { get; set; }
        public MemberType Type { get; set; }
        public DateTime CommitDate { get; set; }
        public DateTime ChangedDate { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }

        protected bool Equals(AssemblyHistoryItem other)
        {
            return string.Equals(FullName, other.FullName)
                && Type == other.Type
                && ChangedDate.Equals(other.ChangedDate)
                && string.Equals(Author, other.Author)
                && string.Equals(Description, other.Description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AssemblyHistoryItem) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (FullName != null ? FullName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (int) Type;
                hashCode = (hashCode*397) ^ ChangedDate.GetHashCode();
                hashCode = (hashCode*397) ^ (Author != null ? Author.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Description != null ? Description.GetHashCode() : 0);
                return hashCode;
            }
        }
    }

    public enum MemberType
    {
        None = 0,
        Class,
        Method
    }
}