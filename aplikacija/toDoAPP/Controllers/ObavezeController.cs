using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using toDoAPP.Models;
using toDoAPP.Service;

namespace toDoAPP.Controllers
{
    [Route("my-todo-list")]
    [ApiController]
    public class ObavezeController : ControllerBase
    {
        private readonly IObavezeService _service;

        public ObavezeController(IObavezeService service)
        {
            _service = service;
        }

        // GET: my-todo-list
        [HttpGet]
        public IEnumerable<Obaveze> GetObavezes()
        {
            return _service.GetAll();
        }
        // POST: my-todo-list/tasks
        [HttpPost("tasks")]
        public ContentResult NapraviObavezu([FromBody] Obaveze data)
        {
            return _service.proveriPodatke(data);
        }
        //// GET: api/Obaveze/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Obaveze>> GetObaveze(int id)
        //{
        //    var obaveze = await _context.Obavezes.FindAsync(id);

        //    if (obaveze == null)
        //    {
        //        return NotFound();
        //    }

        //    return obaveze;
        //}

        //// PUT: api/Obaveze/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutObaveze(int id, Obaveze obaveze)
        //{
        //    if (id != obaveze.ObavezaId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(obaveze).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ObavezeExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Obaveze
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Obaveze>> PostObaveze(Obaveze obaveze)
        //{
        //    _context.Obavezes.Add(obaveze);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetObaveze", new { id = obaveze.ObavezaId }, obaveze);
        //}

        //// DELETE: api/Obaveze/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteObaveze(int id)
        //{
        //    var obaveze = await _context.Obavezes.FindAsync(id);
        //    if (obaveze == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Obavezes.Remove(obaveze);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool ObavezeExists(int id)
        //{
        //    return _context.Obavezes.Any(e => e.ObavezaId == id);
        //}
    }
}
