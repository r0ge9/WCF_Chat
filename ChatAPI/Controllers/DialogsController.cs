using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChatAPI.Models;

namespace ChatAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DialogsController : ControllerBase
    {
        private readonly ChatDbContext _context;

        //public DialogsController(ChatDbContext context)
        //{
        //    _context = context;
        //}
        public DialogsController()
        {
            _context = new ChatDbContext();
        }

        // GET: api/Dialogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dialog>>> GetDialogs()
        {
            Console.WriteLine("est moment");
          if (_context.Dialogs == null)
          {
              return NotFound();
          }
            return await _context.Dialogs.ToListAsync();
        }

        // GET: api/Dialogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dialog>> GetDialog(int id)
        {
          if (_context.Dialogs == null)
          {
              return NotFound();
          }
            var dialog = await _context.Dialogs.FindAsync(id);

            if (dialog == null)
            {
                return NotFound();
            }

            return dialog;
        }

        // PUT: api/Dialogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDialog(int id, Dialog dialog)
        {
            if (id != dialog.Id)
            {
                return BadRequest();
            }

            _context.Entry(dialog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DialogExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Dialogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dialog>> PostDialog(Dialog dialog)
        {
          if (_context.Dialogs == null)
          {
              return Problem("Entity set 'ChatDbContext.Dialogs'  is null.");
          }
            _context.Dialogs.Add(dialog);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DialogExists(dialog.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDialog", new { id = dialog.Id }, dialog);
        }

        // DELETE: api/Dialogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDialog(int id)
        {
            if (_context.Dialogs == null)
            {
                return NotFound();
            }
            var dialog = await _context.Dialogs.FindAsync(id);
            if (dialog == null)
            {
                return NotFound();
            }

            _context.Dialogs.Remove(dialog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DialogExists(int id)
        {
            return (_context.Dialogs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
