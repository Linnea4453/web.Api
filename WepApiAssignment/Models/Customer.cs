﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WepApiAssignment.Models
{
    public class Customer
    {
        public Customer()
        {
            Issues = new HashSet<Issue>();
        }

        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }


        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }

        public virtual ICollection<Issue> Issues { get; set; }
    }
}
