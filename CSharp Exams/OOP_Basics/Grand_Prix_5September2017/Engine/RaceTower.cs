﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    public RaceTower()
    {
        this.drivers = new List<Driver>();
        this.dropoutDrivers = new List<string>();

        this.driverFactory = new DriverFactory();
        this.carFactory = new CarFactory();
        this.tyreFactory = new TyreFactory();

        this.weather = "Sunny";
    }

    public List<Driver> drivers;
    public List<string> dropoutDrivers;

    private Track track;
    private DriverFactory driverFactory;
    private CarFactory carFactory;
    private TyreFactory tyreFactory;

    private string weather;

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.track = new Track(lapsNumber, trackLength);
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        List<string> driverArgs = commandArgs.Take(2).ToList();
        List<string> carArgs = commandArgs.Skip(2).Take(2).ToList();
        List<string> tyreArgs = commandArgs.Skip(4).ToList();

        Tyre tyre = this.tyreFactory.GetTyre(tyreArgs);
        if (tyre == null)
        {
            return;
        }

        Car car = this.carFactory.GetCar(carArgs, tyre);
        if (car == null)
        {
            return;
        }

        Driver driver = this.driverFactory.GetDriver(driverArgs, car);
        if (driver == null)
        {
            return;
        }

        this.drivers.Add(driver);
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        string command = commandArgs[0];
        Driver driver = this.drivers.Find(d => d.Name == commandArgs[1]);
        driver.TotalTime += 20;
        switch (command)
        {
            case "ChangeTyres":
                {
                    List<string> tyreArgs = commandArgs.Skip(2).ToList();
                    driver.Car.Tyre = this.tyreFactory.GetTyre(tyreArgs);
                }
                break;
            case "Refuel":
                {
                    double fuel = double.Parse(commandArgs[2]);

                    driver.Car.ChangeFuelAmount(fuel);
                }
                break;
            default:
                break;
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        int completeLaps;
        if (!int.TryParse(commandArgs[0], out completeLaps))
        {
            return null;
        }
        if (completeLaps > this.track.LapsNumber - this.track.CurrentLap)
        {
            throw new Exception(
                $"There is no time! On lap {this.track.CurrentLap}.");
        }

        StringBuilder result = new StringBuilder();
        int trLength = this.track.TrackLength;
        for (int l = 0; l < completeLaps; l++)
        {
            this.track.CurrentLap++;

            for (int d = 0; d < this.drivers.Count; d++)
            {
                Driver currentDriver = this.drivers[d];

                currentDriver.IncreaseTotalTime(trLength);

                try
                {
                    //1
                    currentDriver.DecreaseFuelAmount(trLength);

                    //2
                    currentDriver.Car.Tyre.DecreaseDegradation();
                }
                catch (Exception ex)
                {
                    this.dropoutDrivers.Add($"{currentDriver.Name} {ex.Message}");
                    this.drivers[d] = null;
                    continue;
                }
            }
            this.drivers.RemoveAll(d => d == null);
            result.Append(this.Overtaking());
        }

        return result.ToString().TrimEnd();
    }

    public string GetLeaderboard()
    {
        StringBuilder sb = new StringBuilder(this.track + Environment.NewLine);

        for (int i = 0; i < this.drivers.Count; i++)
        {
            sb.AppendLine($"{i + 1} " + this.drivers[i]);
        }

        for (int i = this.dropoutDrivers.Count - 1; i >= 0; i--)
        {
            int position = this.dropoutDrivers.Count - i + this.drivers.Count;
            sb.AppendLine($"{position} " + this.dropoutDrivers[i]);
        }

        return sb.ToString().TrimEnd(); ;
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        this.weather = commandArgs[0];
    }

    private string Overtaking()
    {
        StringBuilder sb = new StringBuilder();

        for (int d = this.drivers.Count - 1; d >= 1; d--)
        {
            double interval = 2;
            Driver behindDriver = this.drivers[d];
            Driver aheadDriver = this.drivers[d - 1];

            double difference = behindDriver.TotalTime - aheadDriver.TotalTime;

            if (difference <= interval)
            {
                if (behindDriver.GetType().Name == "AggressiveDriver" &&
                    behindDriver.Car.Tyre.Name == "Ultrasoft")
                {
                    if (this.weather == "Foggy")
                    {
                        this.dropoutDrivers.Add($"{behindDriver.Name} Crashed");
                        this.drivers[d] = null;
                        continue;
                    }
                    interval = 3;
                }

                if (behindDriver.GetType().Name == "EnduranceDriver" &&
                    behindDriver.Car.Tyre.Name == "Hard")
                {
                    if (this.weather == "Rainy")
                    {
                        this.dropoutDrivers.Add($"{behindDriver.Name} Crashed");
                        this.drivers[d] = null;
                        continue;
                    }
                    interval = 3;
                }


                if (difference >= 0)
                {
                    behindDriver.TotalTime -= interval;
                    aheadDriver.TotalTime += interval;

                    sb.AppendFormat("{0} has overtaken {1} on lap {2}." + Environment.NewLine,
                        behindDriver.Name, aheadDriver.Name, this.track.CurrentLap);
                }

                this.drivers[d] = null;
                this.drivers.Insert(d - 1, behindDriver);
                //d--;
            }
        }

        this.drivers.RemoveAll(d => d == null);
        return sb.ToString();
    }
}