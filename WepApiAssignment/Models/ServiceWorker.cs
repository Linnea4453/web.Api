using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace WepApiAssignment.Models
{
    public class ServiceWorker
    {
    

        public ServiceWorker()
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

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }

        public void CreatePasswordHash(string password)
        {
            using (var hmac = new HMACSHA512()) 
            {
                PasswordSalt = hmac.Key;
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public bool ValidatePasswordHash(string password)
        {
            using (var hmac = new HMACSHA512(PasswordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != PasswordHash[i])
                        return false;
                }
            }

            return true;
        }

        public virtual ICollection<Issue> Issues { get; set; }

    }
}
