using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Players
{
    public abstract class Player : Contracts.IPlayer
    {
        private string username;
        private int health;
        private int armour;
        private IGun gun;
        //private bool isAlive;

        protected Player(string username, int health, int armor, IGun gun)
        {
            this.Username = username;
            this.Health = health;
            this.Armor = armor;
            this.Gun = gun;
        }
        public string Username
        {
            get => this.username;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerName);
                }

                this.username = value;
            }
        }
        public int Health
        {
            get => this.health;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerHealth);
                }

                this.health = value;
            }
        }
        public int Armor
        {
            get => this.armour;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerArmor);
                }

                this.armour = value;
            }
        }

        public IGun Gun
        {
            get => this.gun;
            private set
            {

                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunName);
                }

                this.gun = value;
            }
        }

        public bool IsAlive => this.Health > 0;
        //{
        //    get
        //    {
        //        return this.isAlive;
        //    }
        //    private set
        //    {

        //        this.isAlive = value;
        //    }
        //}

        public void TakeDamage(int points)
        {
            if (points <= this.Armor)
            {
                this.Armor -= points;
            }
            else
            {
                points -= this.Armor;
                this.Armor = 0;

                if (points < this.Health)
                {
                    this.Health -= points;
                }
                else
                {
                    this.Health = 0;
                    //this.IsAlive = false;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}: {this.Username}");
            sb.AppendLine($"--Health: {this.Health}");
            sb.AppendLine($"--Armor: {this.Armor}");
            sb.AppendLine($"--Gun: {this.Gun.Name}");

            return sb.ToString().Trim();

        }
    }
}
