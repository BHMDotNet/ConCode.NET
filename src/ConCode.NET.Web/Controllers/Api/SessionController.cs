using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ConCode.NET.Core.Domain;
using ConCode.NET.Core.Domain;
using System.Linq;

namespace ConCode.NET.Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Session")]
    public class SessionController : Controller
    {
        private ISessionService sessionService;

        public SessionController(ISessionService sessionService)
        {
            this.sessionService = sessionService;
        }

        // GET: api/Session
        [HttpGet]
        public IEnumerable<Session> Get()
        {
            return sessionService.GetSessions();
        }

        // GET: api/Session/5
        [HttpGet("{id}", Name = "Get")]
        public Session Get(int id)
        {
            return sessionService.GetSessions().FirstOrDefault(x => x.Id == id);
        }
        
        // POST: api/Session
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Session/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
