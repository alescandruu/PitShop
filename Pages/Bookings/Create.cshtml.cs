using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PitShop.Data;
using PitShop.Models;

namespace PitShop.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly PitShop.Data.PitShopContext _context;

        public CreateModel(PitShop.Data.PitShopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CarId"] = new SelectList(_context.Car, "Id", "Id");
            ViewData["MechanicName"] = new SelectList(_context.Mechanic, "FullName", "FullName");
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Booking.Add(Booking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
