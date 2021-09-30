﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessMultipleExceptions
{
    class Car
    {
        public const int MaxSpeed = 100;

        public int CurrentSpeed { get; set; } = 0;
        public string PetName { get; set; } = "";

        private bool carIsDead;

        private Radio theMusicBox = new Radio();
        public Car() { }
        public Car(string name, int speed)
        {
            CurrentSpeed = speed;
            PetName = name;
        }
        public void CrankTunes(bool state)
        {
            theMusicBox.TurnOn(state);
        }
        public void Accelerate(int delta)
        {
            if (delta<0)
            {
                throw new ArgumentOutOfRangeException("delta", "Speed must be greater than zero!");
            }
            if(carIsDead)
                Console.WriteLine($"{PetName} is out of order...");
            else
            {
                CurrentSpeed += delta;
                if(CurrentSpeed>MaxSpeed)
                {
                    //Console.WriteLine($"{PetName} has overheated!");
                    CurrentSpeed = 0;
                    carIsDead = true;
                    //Exception ex = new Exception($"{PetName} has overheated!");
                    //ex.HelpLink = "https://www.youtube.com";
                    //ex.Data.Add("TimeStamp", $"The car exploded at {DateTime.Now}");
                    //ex.Data.Add("Cause", "You have a lead foot.");
                    //throw ex;
                    CarIsDeadExeption ex = new CarIsDeadExeption($"{PetName} has overheated!", "You have a lead foot", DateTime.Now);
                    ex.HelpLink = "https://www.youtube.com";
                    throw ex;
                }
                else
                {
                    Console.WriteLine($"CurrentSpeed = {CurrentSpeed}");
                }
            }
        }
    }
}
