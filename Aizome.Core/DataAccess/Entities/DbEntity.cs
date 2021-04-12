using System;
using System.ComponentModel.DataAnnotations;

namespace Aizome.Core.DataAccess.Entities
{
    public class DbEntity
    {
        public int Id { get; set; }
        public DateTime? DateAdded { get; set; } = DateTime.UtcNow;
    }
}