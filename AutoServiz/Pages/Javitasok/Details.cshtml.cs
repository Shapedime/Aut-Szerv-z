using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoServiz.Data;
using AutoServiz.Models;

namespace AutoServiz.Pages.Javitasok;

public class DetailsModel : PageModel
{
    private readonly AutoServizContext _context;

    public DetailsModel(AutoServizContext context)
    {
        _context = context;
    }

    public Javitas Javitas { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var javitas = await _context.Javitas
            .Include(j => j.Ugyfel)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (javitas == null)
        {
            return NotFound();
        }

        Javitas = javitas;
        return Page();
    }
}
