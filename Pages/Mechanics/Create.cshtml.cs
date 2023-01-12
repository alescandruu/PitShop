using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PitShop.Data;
using PitShop.Models;

namespace PitShop.Pages.Mechanics
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly PitShop.Data.PitShopContext _context;

        public CreateModel(PitShop.Data.PitShopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Mechanic Mechanic { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Mechanic.Add(Mechanic);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
