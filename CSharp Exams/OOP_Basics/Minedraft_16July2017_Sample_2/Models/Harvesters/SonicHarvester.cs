﻿public class SonicHarvester : Harvester
{
    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor) 
        : base(id, oreOutput)
    {
        this.SonicFactor = sonicFactor;

        //ebati nali vigda che ima override
        //base.EnergyRequirement = energyRequirement;

        this.EnergyRequirement = energyRequirement;
    }

    public int SonicFactor { get; private set; }
    public override double EnergyRequirement
    {
        get => base.EnergyRequirement;
        protected set => base.EnergyRequirement = (value / this.SonicFactor);
    }
}