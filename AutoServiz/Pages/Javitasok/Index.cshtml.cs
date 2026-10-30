using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoServiz.Data;
using AutoServiz.Models;

namespace AutoServiz.Pages.Javitasok;

public class IndexModel : PageModel
{
    private readonly AutoServizContext _context;

    public IndexModel(AutoServizContext context)
    {
        _context = context;
    }

    public IList<Javitas> Javitas { get; set; } = default!;

    public string Hiba { get; set; } = "";

    public async Task OnGetAsync(string? allapot)
    {
        // ha van kiválasztva állapot, akkor csak azokat mutatja
        if (string.IsNullOrEmpty(allapot))
        {
            Javitas = await _context.Javitas
                .Include(j => j.Ugyfel)
                .ToListAsync();
        }
        else
        {
            Javitas = await _context.Javitas
                .Include(j => j.Ugyfel)
                .Where(j => j.Allapot == allapot)
                .ToListAsync();
        }
    }

    // állapot léptetése: Felvéve -> Folyamatban -> Kész
    public async Task<IActionResult> OnPostLeptetAsync(int id)
    {
        var javitas = await _context.Javitas.FindAsync(id);
        if (javitas == null)
        {
            return NotFound();
        }

        if (javitas.Allapot == "Felvéve")
        {
            javitas.Allapot = "Folyamatban";
        }
        else if (javitas.Allapot == "Folyamatban")
        {
            // csak akkor lehet kész, ha meg van adva a költség
            if (javitas.Koltseg <= 0)
            {
                Hiba = "Nem lehet Kész, amíg nincs megadva a költség! (" + javitas.Rendszam + ")";
                await OnGetAsync(null);
                return Page();
            }
            javitas.Allapot = "Kész";
        }

        await _context.SaveChangesAsync();
        return RedirectToPage("./Index");
    }
}
