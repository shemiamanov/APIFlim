using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIFilim.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public bool IsDeleted { get; set; }
        public string ImageUrl  { get; set; }
    }
}
