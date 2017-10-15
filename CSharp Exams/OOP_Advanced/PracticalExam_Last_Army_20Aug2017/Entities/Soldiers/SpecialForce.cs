﻿using System;
using System.Collections.Generic;
using System.Text;

public class SpecialForce : Soldier
{
    private const double OverallSkillMiltiplier = 3.5;

    private readonly List<string> weaponsAllowed = new List<string>
        {
            "Gun",
            "AutomaticMachine",
            "MachineGun",
            "RPG",
            "Helmet",
            "Knife",
            "NightVision"
        };

    public SpecialForce(
        string name, 
        int age, 
        double experience, 
        double endurance
        ) : base(name, age, experience, endurance)
    {
    }

    public override double OverallSkill
    {
        get { return base.OverallSkill * OverallSkillMiltiplier; }
    }

    protected override IReadOnlyList<string> WeaponsAllowed
    {
        get { return this.weaponsAllowed; }
    }

    public override void Regenerate()
    {
        base.Endurance = base.Endurance + 30 + this.Age;
    }

    public override void CompleteMission(IMission mission)
    {

    }
}