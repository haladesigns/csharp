using NBADataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NBACRUD.Controllers
{
    public class GameController : ApiController
    {
        public IEnumerable<Game> Get()
        {
            using (NBAEntities entities = new NBAEntities())
                return entities.Games.ToList();
        }

        public HttpResponseMessage Get(int id)
        {
            using (NBAEntities entities = new NBAEntities())
            {
                var entity = entities.Games.FirstOrDefault(e => e.ID == id);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        "Game with ID " + id.ToString() + " NOT FOUND");
                }
            }
        }

        public HttpResponseMessage Put([FromBody] Game game)
        {
            using (NBAEntities entities = new NBAEntities())
            {
                try
                {
                    var entity = entities.Games.FirstOrDefault(e => e.ID == game.ID);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
                    }
                    else
                    {
                        entity.Team1 = game.Team1;
                        entity.Team2 = game.Team2;
                        entity.Period = game.Period;
                        entity.Time = game.Time;
                        entity.Description = game.Description;
                        entity.ScoreTeam1 = game.ScoreTeam1;
                        entity.ScoreTeam2 = game.ScoreTeam2;

                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, game);
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
            }
        }

        public HttpResponseMessage Post([FromBody]Game game)
        {
            try
            {
                using (NBAEntities entities = new NBAEntities())
                {
                    entities.Games.Add(game);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, game);
                    message.Headers.Location = new Uri(Request.RequestUri + game.ID.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (NBAEntities entities = new NBAEntities())
                {
                    var entity = entities.Games.FirstOrDefault(e => e.ID == id);

                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "ID " + id.ToString() + " NOT FOUND");
                    }
                    else
                    {
                        entities.Games.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
