using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CheekiBreekiWeb.Models;
using Newtonsoft.Json;

namespace CheekiBreekiWeb.Controllers
{
    public class LeaderBoardController : ApiController
    {
        static public List<LeaderBoard> leaderBoard = new List<LeaderBoard>();
        IEnumerable<LeaderBoard> GetFullLeaderBoard()
        {
            return leaderBoard;
        }

        public IHttpActionResult GetLeaderBoard()
        {
            return Json(leaderBoard);
        }
        [HttpPost]
        public IHttpActionResult Post([FromBody] dynamic jsonValue)
        {

            if (jsonValue != null)
            {
                leaderBoard.Add(JsonConvert.DeserializeObject<LeaderBoard>(jsonValue.ToString()));
            }
            leaderBoard = leaderBoard.OrderBy(o => o.Time).OrderByDescending(o => o.Score).ToList<LeaderBoard>();
            if (leaderBoard.Count > 10)
            {
                leaderBoard.RemoveAt(leaderBoard.Count);
            }
            return Ok();
        }
    }
}
