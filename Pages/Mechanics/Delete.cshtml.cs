using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PitShop.Data;
using PitShop.Models;

namespace PitShop.Pages.Mechanics
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly PitShop.Data.PitShopContext _context;

        public DeleteModel(PitShop.Data.PitShopContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Mechanic Mechanic { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Mechanic == null)
            {
                return NotFound();
            }

            var mechanic = await _context.Mechanic.FirstOrDefaultAsync(m => m.Id == id);

            if (mechanic == null)
            {
                return NotFound();
            }
            else 
            {
                Mechanic = mechanic;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Mechanic == null)
            {
                return NotFound();
            }
            var mechanic = await _context.Mechanic.FindAsync(id);

            if (mechanic != null)
            {
                Mechanic = mechanic;
                _context.Mechanic.Remove(Mechanic);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
