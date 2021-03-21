using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WepApiAssignment.ViewModels
{
    public class CreateIssueModel
    {
        public string Description { get; set; }

        public int CustomerId { get; set; }

        public int ServiceWorkerId { get; set; }

        public DateTime CreationDate { get; set; }

        public string IssueStatus { get; set; }
    }
}
