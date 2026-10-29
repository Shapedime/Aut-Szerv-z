using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoServiz.Data;
using AutoServiz.Models;

namespace AutoServiz.Pages.Ugyfelek;

public class DeleteModel : PageModel
{
    private readonly AutoServizContext _context;

    public DeleteModel(AutoServizContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Ugyfel Ugyfel { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var ugyfel = await _context.Ugyfel.FirstOrDefaultAsync(m => m.Id == id);

        if (ugyfel == null)
        {
            return NotFound();
        }

        Ugyfel = ugyfel;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var ugyfel = await _context.Ugyfel.FindAsync(id);
        if (ugyfel != null)
        {
            Ugyfel = ugyfel;
            _context.Ugyfel.Remove(Ugyfel);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
