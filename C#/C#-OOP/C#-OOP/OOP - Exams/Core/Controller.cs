using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Linq;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private IGarage garage;
        private IProcedure charge;
        private IProcedure chip;
        private IProcedure polish;
        private IProcedure rest;
        private IProcedure techCheck;
        private IProcedure work;
        public Controller()
        {
            this.garage = new Garage();
            this.charge = new Charge();
            this.chip = new Chip();
            this.polish = new Polish();
            this.rest = new Rest();
            this.techCheck = new TechCheck();
            this.work = new Work();
        }
        public string Charge(string robotName, int procedureTime)
        {
            this.FindIfRobotExist(robotName);
            IRobot robot = this.garage.Robots.FirstOrDefault(x => x.Key == robotName).Value;

            this.charge.DoService(robot, procedureTime);

            return string.Format(OutputMessages.ChargeProcedure, robotName);
        }

        public string Chip(string robotName, int procedureTime)
        {
            this.FindIfRobotExist(robotName);
            IRobot robot = this.garage.Robots.FirstOrDefault(x => x.Key == robotName).Value;

            this.chip.DoService(robot, procedureTime);

            return string.Format(OutputMessages.ChipProcedure, robotName);
        }

        public string History(string procedureType)
        {
            if (procedureType == "Chip")
            {
                return this.chip.History();
            }
            else if (procedureType == "TechCheck")
            {
                return this.techCheck.History();
            }
            else if (procedureType == "Rest")
            {
                return this.rest.History();
            }
            else if (procedureType == "Work")
            {
                return this.work.History();
            }
            else if (procedureType == "Charge")
            {
                return this.charge.History();
            }
            else if (procedureType == "Polish")
            {
                return this.polish.History();
            }
            else
            {
                return null;
            }
        }


        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot = null;

            if (robotType == "HouseholdRobot")
            {
                robot = new HouseholdRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == "PetRobot")
            {
                robot = new PetRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == "WalkerRobot")
            {
                robot = new WalkerRobot(name, energy, happiness, procedureTime);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidRobotType, robotType));
            }
            this.garage.Manufacture(robot);

            return string.Format(OutputMessages.RobotManufactured, name);
        }

        public string Polish(string robotName, int procedureTime)
        {
            this.FindIfRobotExist(robotName);
            IRobot robot = this.garage.Robots.FirstOrDefault(x => x.Key == robotName).Value;

            this.polish.DoService(robot, procedureTime);

            return string.Format(OutputMessages.PolishProcedure, robotName);
        }

        public string Rest(string robotName, int procedureTime)
        {
            this.FindIfRobotExist(robotName);
            IRobot robot = this.garage.Robots.FirstOrDefault(x => x.Key == robotName).Value;

            this.rest.DoService(robot, procedureTime);

            return string.Format(OutputMessages.RestProcedure, robotName);
        }

        public string Sell(string robotName, string ownerName)
        {
            this.FindIfRobotExist(robotName);
            IRobot robot = this.garage.Robots.FirstOrDefault(x => x.Key == robotName).Value;

            this.garage.Sell(robotName, ownerName);

            if (robot.IsChipped)
            {
                return string.Format(OutputMessages.SellChippedRobot, ownerName);
            }
            else
            {
                return string.Format(OutputMessages.SellNotChippedRobot, ownerName);
            }
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            this.FindIfRobotExist(robotName);
            IRobot robot = this.garage.Robots.FirstOrDefault(x => x.Key == robotName).Value;

            this.techCheck.DoService(robot, procedureTime);

            return string.Format(OutputMessages.TechCheckProcedure, robotName);
        }

        public string Work(string robotName, int procedureTime)
        {
            this.FindIfRobotExist(robotName);
            IRobot robot = this.garage.Robots.FirstOrDefault(x => x.Key == robotName).Value;

            this.work.DoService(robot, procedureTime);

            return string.Format(OutputMessages.WorkProcedure, robotName, procedureTime);
        }

        public void FindIfRobotExist(string name)
        {
            if (!this.garage.Robots.ContainsKey(name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, name));
            }
        }
    }
}
