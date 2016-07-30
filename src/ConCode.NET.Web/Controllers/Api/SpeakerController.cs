using ConCode.NET.Domain;
using ConCode.NET.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ConCode.NET.Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Speaker")]
    public class SpeakerController : Controller
    {
        private ISpeakerService speakerService;

        public SpeakerController(ISpeakerService speakerService)
        {
            this.speakerService = speakerService;
        }


        /// <summary>
        /// GET /api/Speaker - Get all Speakers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return speakerService.GetSpeakers();
        }

        /// <summary>
        /// GET /api/Speaker/5 -- Get all Speakers by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetSpeakers")]
        public User Get(int id)
        {
            return speakerService.GetSpeakers().FirstOrDefault(x => x.Id == id);
        }


        /// <summary>
        /// POST /api/Speaker -- Add a new item
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }


        /// <summary>
        /// PUT /api/Speaker/5 -- Update an existing item
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }


        /// <summary>
        /// DELETE /api/Speaker/5 -- Delete an item
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
