using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoServiz.Data;
using AutoServiz.Models;

namespace AutoServiz.Pages.Javitasok;

public class DeleteModel : PageModel
{
    private readonly AutoServizContext _context;

    public DeleteModel(AutoServizContext context)
    {
        _context = context;
    }

    [BindProperty]
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

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var javitas = await _context.Javitas.FindAsync(id);
        if (javitas != null)
        {
            Javitas = javitas;
            _context.Javitas.Remove(Javitas);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
