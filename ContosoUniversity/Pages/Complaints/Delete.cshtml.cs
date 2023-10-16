using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity.Pages.Complaints
{
    public class DeleteModel : PageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public DeleteModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Complaint Complaint { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.StudentComplaints == null)
            {
                return NotFound();
            }

            var complaint = await _context.StudentComplaints.FirstOrDefaultAsync(m => m.ID == id);

            if (complaint == null)
            {
                return NotFound();
            }
            else 
            {
                Complaint = complaint;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.StudentComplaints == null)
            {
                return NotFound();
            }
            var complaint = await _context.StudentComplaints.FindAsync(id);

            if (complaint != null)
            {
                Complaint = complaint;
                _context.StudentComplaints.Remove(Complaint);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
