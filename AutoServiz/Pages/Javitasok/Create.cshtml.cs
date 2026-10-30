using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoServiz.Data;
using AutoServiz.Models;

namespace AutoServiz.Pages.Javitasok;

public class CreateModel : PageModel
{
    private readonly AutoServizContext _context;

    public CreateModel(AutoServizContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        ViewData["UgyfelId"] = new SelectList(_context.Ugyfel, "Id", "Nev");
        return Page();
    }

    [BindProperty]
    public Javitas Javitas { get; set; } = default!;

    public async Task<IActionResult> OnPostAsync()
    {
        if (Javitas.Allapot == "Kész" && Javitas.Koltseg <= 0)
        {
            ModelState.AddModelError("Javitas.Koltseg", "Kész javításnál meg kell adni a költséget!");
        }

        if (!ModelState.IsValid)
        {
            ViewData["UgyfelId"] = new SelectList(_context.Ugyfel, "Id", "Nev");
            return Page();
        }

        _context.Javitas.Add(Javitas);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
