using Domain.Models;

namespace Application.DTOs;

public class StatsResponse(Country country, double imcMoyen, double tailleMediane)
{
    public Country Country { get; set; } = country;
    public double IMCMoyen { get; set; } = imcMoyen;
    public double TailleMediane { get; set; } = tailleMediane;
}
