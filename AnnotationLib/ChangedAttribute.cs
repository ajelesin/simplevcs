using System;
using System.Globalization;

namespace AnnotationLib
{
    public class ChangedAttribute : Attribute
    {
        private readonly DateTime _changeDate;
        private readonly string _author;
        private readonly string _description;

        public ChangedAttribute(string changeDate, string author, string description)
        {
            _changeDate = DateTime.ParseExact(changeDate, "dd'/'MM'/'yyyy", CultureInfo.InvariantCulture);
            _author = author;
            _description = description;
        }

        public DateTime ChangeDate { get { return _changeDate; } }
        public string Author { get { return _author; } }
        public string Description { get { return _description;} }
    }
}
