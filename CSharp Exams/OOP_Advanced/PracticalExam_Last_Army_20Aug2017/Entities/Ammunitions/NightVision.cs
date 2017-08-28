﻿using System;

public class NightVision : Ammunition
{
    public const double NightVisionWeight = 0.8;

    public NightVision(string name)
        : base (name)
    {
    }

    public override double Weight
    {
        get { return NightVisionWeight; }
    }
}