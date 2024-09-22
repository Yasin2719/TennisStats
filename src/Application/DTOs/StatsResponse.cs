using Domain.Models;

namespace Application.DTOs;

public class StatsResponse(Country country, decimal imcMoyen, int tailleMediane)
{
    public Country Country { get; set; } = country;
    public decimal IMCMoyen { get; set; } = imcMoyen;
    public int TailleMediane { get; set; } = tailleMediane;
}
