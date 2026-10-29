using System.ComponentModel.DataAnnotations;

namespace AutoServiz.Models;

public class Ugyfel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "A nevet kötelező megadni!")]
    [StringLength(100)]
    [Display(Name = "Név")]
    public string Nev { get; set; } = "";

    [StringLength(20)]
    public string? Telefon { get; set; }

    [EmailAddress(ErrorMessage = "Nem jó az email cím!")]
    public string? Email { get; set; }

    public List<Javitas> Javitasok { get; set; } = new List<Javitas>();
}
