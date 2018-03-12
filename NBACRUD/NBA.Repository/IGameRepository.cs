using NBADataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA.Repository
{
    public interface IGameRepository : IDisposable
    {
        IEnumerable<Game> GetGames();
        Game GetGameByID(int gameId);
        void PutGame(Game game);
        void DeleteGame(int gameId);
        void PostGame(Game game);
        void Save();
    }
}
