using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoServiz.Data;
using AutoServiz.Models;

namespace AutoServiz.Pages.Javitasok;

public class EditModel : PageModel
{
    private readonly AutoServizContext _context;

    public EditModel(AutoServizContext context)
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

        var javitas = await _context.Javitas.FirstOrDefaultAsync(m => m.Id == id);
        if (javitas == null)
        {
            return NotFound();
        }
        Javitas = javitas;
        ViewData["UgyfelId"] = new SelectList(_context.Ugyfel, "Id", "Nev");
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            ViewData["UgyfelId"] = new SelectList(_context.Ugyfel, "Id", "Nev");
            return Page();
        }

        _context.Attach(Javitas).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!JavitasExists(Javitas.Id))
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

    private bool JavitasExists(int id)
    {
        return _context.Javitas.Any(e => e.Id == id);
    }
}
