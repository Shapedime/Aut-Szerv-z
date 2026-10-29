using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AutoServiz.Data;
using AutoServiz.Models;

namespace AutoServiz.Pages.Ugyfelek;

public class CreateModel : PageModel
{
    private readonly AutoServizContext _context;

    public CreateModel(AutoServizContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Ugyfel Ugyfel { get; set; } = default!;

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Ugyfel.Add(Ugyfel);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
