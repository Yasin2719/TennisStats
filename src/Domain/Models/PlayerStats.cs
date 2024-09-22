﻿namespace Domain.Models;

public class PlayerStats
{
    public int Rank { get; set; }
    public int Points { get; set; }
    public int Weight { get; set; }
    public int Height { get; set; }
    public int Age { get; set; }
    public int[] Last {  get; set; }
}
