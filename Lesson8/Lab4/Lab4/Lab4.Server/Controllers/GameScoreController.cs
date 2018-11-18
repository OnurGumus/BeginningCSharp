using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab4.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameScoreController : ControllerBase
    {

        static volatile GameScore currentScore;

        static readonly object locker = new object();
        // GET api/values
        [HttpGet]
        public ActionResult<GameScore> Get()
        {
            lock (locker)
            {
                return currentScore;
            }
        }



        // POST api/values
        [HttpPost]
        public void Post([FromBody] GameScore value)
        {
            lock (locker)
            {
                if (currentScore == null)
                    currentScore = value;
                else
                {
                    if (currentScore.BestAttempt >= value.BestAttempt)
                    {
                        currentScore = value;
                    }
                }
            }
        }
    }

}
