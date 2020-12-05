using BountyZone.Core.Entities;
using BountyZone.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BountyZone.Infrastructure.Repositories
{
    public class PlayerRepository : EntityFrameworkRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(BountyZoneDbContext dbContext) : base(dbContext)
        {
        }

        public Player CreatePlayerWithRole(Player player)
        {
            using var dbContextTransaction = _dbContext.Database.BeginTransaction();

            PlayerRole playerRole = _dbContext.PlayerRoles.Find(player.PlayerRoleID);

            var newPlayer = _dbContext.Players.Add(player);
            _dbContext.SaveChanges();

            if (playerRole.Type == "Hunter")
                _dbContext.Hunters.Add(new Hunter { PlayerID = player.ID });
            else if (playerRole.Type == "Leader")
                _dbContext.Leaders.Add(new Leader { PlayerID = player.ID });
            else
                throw new EntryPointNotFoundException("Could not determine the player role type");

            _dbContext.SaveChanges();

            dbContextTransaction.Commit();

            return newPlayer.Entity;
        }

        public Player FindPlayerByEmail(string email)
        {
            return _dbContext.Players
                    .Include(player => player.PlayerRole)
                    .FirstOrDefault(player => player.Email == email);
        }

        public IEnumerable<PlayerRole> GetPlayerRoles()
        {
            return _dbContext.PlayerRoles.ToList();
        }
    }
}
