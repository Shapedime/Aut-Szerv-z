using System.ComponentModel.DataAnnotations;

namespace AutoServiz.Models;

public class Javitas
{
    public int Id { get; set; }

    [Display(Name = "Ügyfél")]
    public int UgyfelId { get; set; }
    public Ugyfel? Ugyfel { get; set; }

    [Required(ErrorMessage = "A rendszámot kötelező megadni!")]
    [StringLength(10)]
    [RegularExpression(@"^[A-Z]{3}-[0-9]{3}$", ErrorMessage = "A rendszám formátuma: ABC-123 (nagybetűkkel)")]
    [Display(Name = "Rendszám")]
    public string Rendszam { get; set; } = "";

    [StringLength(300)]
    [Display(Name = "Leírás")]
    public string? Leiras { get; set; }

    [Display(Name = "Költség (Ft)")]
    public int Koltseg { get; set; }

    // Felvéve, Folyamatban vagy Kész
    [Display(Name = "Állapot")]
    public string Allapot { get; set; } = "Felvéve";

    [DataType(DataType.Date)]
    [Display(Name = "Felvétel dátuma")]
    public DateTime FelvetelDatuma { get; set; } = DateTime.Today;
}
