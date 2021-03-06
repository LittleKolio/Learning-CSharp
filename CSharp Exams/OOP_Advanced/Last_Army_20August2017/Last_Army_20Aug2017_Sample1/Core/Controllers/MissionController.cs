﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class MissionController : IMissionController
{
    private Queue<IMission> missionQueue;
    private IArmy army;
    private IWareHouse wareHouse;


    public MissionController(IArmy army, IWareHouse wareHouse)
    {
        this.army = army;
        this.wareHouse = wareHouse;
        this.missionQueue = new Queue<IMission>();
        this.SuccessMissionCounter = 0;
        this.FailedMissionCounter = 0;
    }

    public int SuccessMissionCounter { get; private set; }

    public int FailedMissionCounter { get; private set; }

    public Queue<IMission> Missions => this.missionQueue;

    public string PerformMission(IMission mission)
    {
        StringBuilder sb = new StringBuilder();

        if (this.missionQueue.Count >= 3)
        {
            IMission oldesMission = this.missionQueue.Dequeue();
            sb.AppendLine(string.Format(OutputMessages.MissionDeclined, oldesMission.Name));
            this.FailedMissionCounter++;
        }

        this.missionQueue.Enqueue(mission);

        int missionCount = this.missionQueue.Count;
        for (int i = 0; i < missionCount; i++)
        {
            IList<ISoldier> soldiers = this.army.Soldiers.ToList();

            this.wareHouse.EquipArmy(soldiers);

            IMission currentMission = this.missionQueue.Dequeue();

            IList<ISoldier> currentMissionTeam = this.CollectMissionTeam(currentMission);

            bool successful = this.ExecuteMission(currentMission, currentMissionTeam);

            if (successful)
            {
                sb.AppendLine(string.Format(OutputMessages.MissionSuccessful, currentMission.Name));
            }
            else
            {
                this.missionQueue.Enqueue(currentMission);
                sb.AppendLine(string.Format(OutputMessages.MissionOnHold, currentMission.Name));
            }
        }

        return sb.ToString().TrimEnd();
    }

    private bool ExecuteMission(IMission mission, IList<ISoldier> missionTeam)
    {
        double teamOverallSkill = missionTeam
            .Select(s => s.OverallSkill)
            .Sum();

        if (teamOverallSkill >= mission.ScoreToComplete)
        {
            foreach (ISoldier soldier in missionTeam)
            {
                soldier.CompleteMission(mission);
            }
            this.SuccessMissionCounter++;
            return true;
        }

        return false;
    }

    private List<ISoldier> CollectMissionTeam(IMission mission)
    {
        List<ISoldier> missionTeam = this.army
            .Soldiers
            .Where(s => s.ReadyForMission(mission))
            .ToList();

        return missionTeam;
    }

    public void FailMissionsOnHold()
    {
        while (this.missionQueue.Count > 0)
        {
            this.FailedMissionCounter++;
            this.missionQueue.Dequeue();
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder("Results:" + Environment.NewLine);
        sb.AppendLine($"Successful missions - {this.SuccessMissionCounter}")
            .AppendLine($"Failed missions - {this.FailedMissionCounter}");

        return sb.ToString().TrimEnd();
    }
}