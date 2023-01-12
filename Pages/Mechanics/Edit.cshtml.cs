using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PitShop.Data;
using PitShop.Models;

namespace PitShop.Pages.Mechanics
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly PitShop.Data.PitShopContext _context;

        public EditModel(PitShop.Data.PitShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Mechanic Mechanic { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Mechanic == null)
            {
                return NotFound();
            }

            var mechanic =  await _context.Mechanic.FirstOrDefaultAsync(m => m.Id == id);
            if (mechanic == null)
            {
                return NotFound();
            }
            Mechanic = mechanic;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Mechanic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MechanicExists(Mechanic.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MechanicExists(int id)
        {
          return _context.Mechanic.Any(e => e.Id == id);
        }
    }
}
