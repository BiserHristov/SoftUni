using CounterStrike.Core.Contracts;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using CounterStrike.Core.Factory;
using CounterStrike.Repositories;
using CounterStrike.Repositories.Contracts;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IGun> guns;
        private IRepository<IPlayer> players;
        private IMap map;
        private IPlayerFactory playerFactory;
        private IGunFactory gunFactory;


        public Controller()
        {
            this.guns = new GunRepository();
            this.players = new PlayerRepository();
            this.playerFactory= new PlayerFactory();
            this.gunFactory= new GunFactory();
            this.map = new Map();
        }



        public string AddGun(string type, string name, int bulletsCount)
        {
            if (nameof(Pistol) != type && nameof(Rifle) != type)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }

            IGun currentGun = gunFactory.CreateGun(type,name, bulletsCount);


            this.guns.Add(currentGun);

            return $"Successfully added gun {currentGun.Name}.";
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {

            IGun searchGun = this.guns.FindByName(gunName);
            if (searchGun == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }

            if (nameof(Terrorist) != type && nameof(CounterTerrorist) != type)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }

           


            IPlayer currentPlayer = playerFactory.CreatePlayer( type,  username,  health,  armor,  searchGun);



            this.players.Add(currentPlayer);

            return $"Successfully added player {currentPlayer.Username}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            var sortedPlayers = this.players.Models
                .OrderBy(p => p.GetType().Name)
                .ThenByDescending(p => p.Health)
                .ThenBy(p => p.Username)
                .ToList();

            foreach (var player in sortedPlayers)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().Trim();
        }

        public string StartGame()
        {
            var allalivePlayers = this.players.Models.Where(p => p.IsAlive).ToList();
            return this.map.Start(allalivePlayers);
        }
    }
}
