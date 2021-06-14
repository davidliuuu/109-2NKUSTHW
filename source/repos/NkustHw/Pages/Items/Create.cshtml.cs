using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPages.Data;
using RazorPages.Models;

namespace RazorPages.Pages.Items
{
    public class CreateModel : PageModel
    {
        private readonly RazorPages.Data.RazorPagesContext _context;

        public CreateModel(RazorPages.Data.RazorPagesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Iteminfo Iteminfo { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Iteminfo.Add(Iteminfo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
