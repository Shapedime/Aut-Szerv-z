using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoServiz.Data;
using AutoServiz.Models;

namespace AutoServiz.Pages.Ugyfelek;

public class EditModel : PageModel
{
    private readonly AutoServizContext _context;

    public EditModel(AutoServizContext context)
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

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Ugyfel).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UgyfelExists(Ugyfel.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool UgyfelExists(int id)
    {
        return _context.Ugyfel.Any(e => e.Id == id);
    }
}
