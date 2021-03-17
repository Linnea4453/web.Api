using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WepApiAssignment.Models
{
    public class Issue
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int ServiceWorkerId { get; set; }
        
        [Required]
        public DateTime IssueDate { get; set; }
        public DateTime? ResolveDate { get; set; }

        [Required]
        public string IssueDescription { get; set; }

        [Required]
        public string IssueStatus { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ServiceWorker ServiceWorker { get; set; }
    }
}
