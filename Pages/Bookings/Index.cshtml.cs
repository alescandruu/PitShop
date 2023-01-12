using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PitShop.Data;
using PitShop.Models;

namespace PitShop.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private readonly PitShop.Data.PitShopContext _context;

        public IndexModel(PitShop.Data.PitShopContext context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Booking != null)
            {
                Booking = await _context.Booking
                .Include(b => b.Car)
                .Include(b => b.Mechanic).ToListAsync();
            }
        }
    }
}
