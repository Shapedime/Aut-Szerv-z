using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoServiz.Data;
using AutoServiz.Models;

namespace AutoServiz.Pages.Ugyfelek;

public class IndexModel : PageModel
{
    private readonly AutoServizContext _context;

    public IndexModel(AutoServizContext context)
    {
        _context = context;
    }

    public IList<Ugyfel> Ugyfel { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Ugyfel = await _context.Ugyfel.ToListAsync();
    }
}
