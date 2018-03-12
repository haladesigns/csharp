using System;
using System.Collections.Generic;
using NBADataAccess;
using System.Linq;
using System.Data.Entity;

namespace NBA.Repository
{
    class GameRepository : IGameRepository, IDisposable
    {
        private NBAEntities context;

        public GameRepository(NBAEntities context)
        {
            this.context = context;
        }

        public Game GetGameByID(int gameId)
        {
            return context.Games.Find(gameId);
        }

        public IEnumerable<Game> GetGames()
        {
            return context.Games.ToList();
        }

        public void PostGame(Game game)
        {
            context.Games.Add(game);
        }

        public void PutGame(Game game)
        {
            context.Entry(game).State = EntityState.Modified;
        }

        public void DeleteGame(int gameId)
        {
            Game game = context.Games.Find(gameId);
            context.Games.Remove(game);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
