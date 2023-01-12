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
    public class IndexModel : PageModel
    {
        private readonly PitShop.Data.PitShopContext _context;

        public IndexModel(PitShop.Data.PitShopContext context)
        {
            _context = context;
        }

        public IList<Mechanic> Mechanic { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Mechanic != null)
            {
                Mechanic = await _context.Mechanic.ToListAsync();
            }
        }
    }
}
