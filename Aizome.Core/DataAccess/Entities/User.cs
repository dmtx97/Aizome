using System.Collections.Generic;

namespace Aizome.Core.DataAccess.Entities
{
    public class User : DbEntity
    {
        public User()
        {
            Jeans = new List<Jean>();
        }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string UserName { get; set; }
        
        public ICollection<Jean> Jeans { get; set; }
    }
}