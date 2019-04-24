using System;
using System.ComponentModel.DataAnnotations;

namespace our_project.Models
{
    public class UnemploymentStat
    {
        [Key]
        public int InstanceId { get; set; }
        public int StateCode { get; set; }
        public int CountyCode { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public int Year { get; set; }
        public int ManPowerForce { get; set; }
        public int Employed { get; set; }
        public int Unemployed { get; set; }
        public float UnemploymentRate { get; set; }
    }
}