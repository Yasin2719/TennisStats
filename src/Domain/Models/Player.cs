﻿namespace Domain.Models;

public class Player
{
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string ShortName { get; set; }
    public string Sex { get; set; }
    public Country Country { get; set; }
    public string Picture { get; set; }
    public PlayerStats Data { get; set; }
}