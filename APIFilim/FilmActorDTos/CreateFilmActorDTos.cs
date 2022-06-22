using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIFilim.FilmActorDTos
{
    public class CreateFilmActorDTos
    {
        public string FullName { get; set; }
        public bool IsDeleted { get; set; }
        public string ImageUrl { get; set; }
    }
}
