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
    public class DetailsModel : PageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public DetailsModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

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
    }
}
