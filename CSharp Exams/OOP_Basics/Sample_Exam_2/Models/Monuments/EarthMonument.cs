﻿using System;

public class EarthMonument : Monument
{

    public EarthMonument(string name, int earthAffinity) 
        : base(name)
    {
        this.EarthAffinity = earthAffinity;
    }
    public int EarthAffinity { get; set; }

    public override int Bonus()
    {
        return this.EarthAffinity;
    }
    public override string ToString()
    {
        return $"Earth Monument: {base.Name}, Earth Affinity: {this.EarthAffinity}";
    }
}
