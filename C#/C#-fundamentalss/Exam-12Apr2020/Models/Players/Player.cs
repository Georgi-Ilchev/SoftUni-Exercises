using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string userName;
        private int health;
        private int armor;
        private IGun gun;

        protected Player(string username, int health, int armor, IGun gun)
        {
            this.Username = username;
            this.Health = health;
            this.Armor = armor;
            this.Gun = gun;
        }

        public string Username
        {
            get => this.userName;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidPlayerName);
                }
                this.userName = value;
            }
        }

        public int Health
        {
            get => this.health;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidPlayerHealth);
                }
                this.health = value;
            }
        }

        public int Armor
        {
            get => this.armor;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidPlayerArmor);
                }
                this.armor = value;
            }
        }

        public IGun Gun
        {
            get
            {
                return this.gun;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidGun);
                }

                this.gun = value;
            }
        }

        public bool IsAlive => this.Health > 0; //? true : false;

        public void TakeDamage(int points)
        {
            //1
            if (this.Armor >= points)
            {
                this.Armor -= points;
            }
            else
            {
                points -= this.Armor;

                this.Armor = 0;

                if (this.Health > points)
                {
                    this.Health -= points;
                }
                else
                {
                    this.Health = 0;
                }
            }
                //2
            //int currentpoints = points;

            //if (this.Armor - currentpoints >= 0)
            //{
            //    this.Armor -= currentpoints;
            //}
            //else if (this.Armor - currentpoints < 0)
            //{
            //    currentpoints = currentpoints - this.Armor;
            //    this.Armor = 0;
            //    this.Health -= currentpoints;
            //}

            //if (this.Health <= 0)
            //{

            //    this.Health = 0;
            //}

            //3
            //int currentpoints = points;

            //if (this.armor - currentpoints >= 0)
            //{
            //    this.armor -= currentpoints;
            //}
            //else if (this.armor - currentpoints < 0)
            //{
            //    currentpoints = currentpoints - this.armor;
            //    this.armor = 0;
            //    this.health -= currentpoints;
            //}

            //if (this.health <= 0)
            //{

            //    this.health = 0;
            //}
        }
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb
                .AppendLine($"{this.GetType().Name}: {this.Username}")
                .AppendLine($"--Health: {this.Health}")
                .AppendLine($"--Armor: {this.Armor}")
                .AppendLine($"--Gun: {this.Gun.Name}");

            return sb.ToString().TrimEnd();
        }
    }
}
