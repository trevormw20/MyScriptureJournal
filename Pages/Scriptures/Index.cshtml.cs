using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Data;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal.Data.MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournal.Data.MyScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Books { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Book { get; set; }
        public string BookNameSort { get; set; }
        public string JournalDateSort { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            //Sorting books and dates
            BookNameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            JournalDateSort = sortOrder == "Date" ? "date_desc" : "Date";


            // Use LINQ to get list of Books.
            IQueryable<string> genreQuery = from m in _context.Scripture
                                            orderby m.Book
                                            select m.Book;

            var Scriptures = from m in _context.Scripture
                             select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                Scriptures = Scriptures.Where(s => s.Book.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(Book))
            {
                Scriptures = Scriptures.Where(x => x.Book == Book);
            }
            Books = new SelectList(await genreQuery.Distinct().ToListAsync());

                /*switch (sortOrder)
                {
                    case "name_desc":
                        Scriptures = Scriptures.OrderByDescending(s => s.Book);
                        break;
                    case "Date":
                        Scriptures = Scriptures.OrderBy(s => s.Book);
                        break;
                    case "date_desc":
                        Scriptures = Scriptures.OrderByDescending(s => s.Book);
                        break;
                    default:
                        Scriptures = Scriptures.OrderBy(s => s.Book);
                        break;
                }*/


            Scripture = await Scriptures.ToListAsync();

        }
    }
}
