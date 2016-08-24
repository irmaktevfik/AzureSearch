using Microsoft.Azure.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchRepository.Tests.Models
{
    [SerializePropertyNamesAsCamelCase]
    public class Telephone 
    {
        public string TelNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelType { get; set; }
        public string[] Tags { get; set; }
        public double LocationMargin { get; set; }
        public bool IsPersonal { get; set; }
        public override string ToString()
        {
            return String.Format(
            "ID: {0}\tName: {1}\tCategory: {2}\tTags: [{3}]",
            TelNo,
            String.Join(" ",FirstName,LastName),
            TelType,
            (Tags != null) ? String.Join(", ", Tags) : String.Empty);
        }
    }
}
