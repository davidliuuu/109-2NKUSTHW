using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPages.Data;
using RazorPages.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorPages.Pages.Items
{
    public class IndexModel : PageModel
    {
        private readonly RazorPages.Data.RazorPagesContext _context;

        public IndexModel(RazorPages.Data.RazorPagesContext context)
        {
            _context = context;
        }

        public IList<Iteminfo> Iteminfo { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string  ItemGenre { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Iteminfo
                                            orderby m.Genre
                                            select m.Genre;

            var movies = from m in _context.Iteminfo
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(ItemGenre))
            {
                movies = movies.Where(x => x.Genre == ItemGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Iteminfo = await movies.ToListAsync();


        }
    }
}
