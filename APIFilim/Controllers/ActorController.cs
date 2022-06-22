using APIFilim.DAL;
using APIFilim.FilmActorDTos;
using APIFilim.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIFilim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private AppDbContext _context { get;  }
        public ActorController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("")]
        public async Task<IActionResult> All()
        {
            return Ok(await _context.Actors.ToListAsync());
        }
        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            Actor actor = await _context.Actors.Where(a => a.IsDeleted == false && a.Id == id).FirstOrDefaultAsync();
            if (actor == null) return BadRequest();
            return Ok(actor);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateFilmActorDTos createFilmActorDTos)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            Actor actor = new Actor
            {
                FullName = createFilmActorDTos.FullName,
                ImageUrl = createFilmActorDTos.ImageUrl,
                IsDeleted = false
            };
            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();
            return Ok(createFilmActorDTos);
        }
        [HttpPut("id")]
        public IActionResult Update(int id, Actor actor)
        {
            Actor aktyor = _context.Actors.Find(id);
            if (aktyor==null )
            {
                return StatusCode(StatusCodes.Status400BadRequest);

            }
            aktyor.FullName = actor.FullName;
            aktyor.ImageUrl = actor.ImageUrl;
            _context.SaveChanges();
            return Ok(actor);
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            Actor actor = _context.Actors.Find(id);
            if (actor==null)
            {
                return BadRequest();
            }
            _context.Actors.Remove(actor);
            _context.SaveChanges();
            return Ok(actor);
        }
    }
}
