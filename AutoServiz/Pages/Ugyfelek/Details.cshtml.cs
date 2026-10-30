using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoServiz.Data;
using AutoServiz.Models;

namespace AutoServiz.Pages.Ugyfelek;

public class DetailsModel : PageModel
{
    private readonly AutoServizContext _context;

    public DetailsModel(AutoServizContext context)
    {
        _context = context;
    }

    public Ugyfel Ugyfel { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        // a javításait is betölti
        var ugyfel = await _context.Ugyfel
            .Include(u => u.Javitasok)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (ugyfel == null)
        {
            return NotFound();
        }

        Ugyfel = ugyfel;
        return Page();
    }
}
