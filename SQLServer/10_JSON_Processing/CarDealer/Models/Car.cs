﻿namespace CarDealer.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// A car has many parts and one part can be placed in many cars
    /// </summary>
    public class Car
    {
        private ICollection<Part> parts;
        public Car()
        {
            this.Parts = new HashSet<Part>();
        }

        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int TravelledDistance { get; set; } // kilometers

        public virtual ICollection<Part> Parts
        {
            get { return this.parts; }
            set { this.parts = value; }
        }
    }
}
