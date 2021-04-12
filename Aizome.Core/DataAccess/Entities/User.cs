using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aizome.Core.DataAccess.Entities
{
    public class User : DbEntity
    {
        public User()
        {
            Jeans = new List<Jean>();
        }

        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public ICollection<Jean> Jeans { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
    }
}