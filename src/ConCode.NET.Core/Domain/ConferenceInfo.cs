using System;
using System.Collections.Generic;
using ConCode.NET.Core.Domain;
namespace ConCode.NET.Core
{
    /// <summary>
    /// This represents the high level details of a conference.
    /// </summary>
    public class ConferenceInfo
    {
        /// <summary>
        /// Name of the conference
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }
        
        /// <summary>
        /// Description of the conference
        /// </summary>
        /// <returns></returns>
        public string Description { get; set; }

        /// <summary>
         /// List of conference dates 
         /// </summary>
         /// <returns></returns>
         public IEnumerable<DateTime> Dates {get; set;}
        
        /// <summary>
        /// List of conference organizers
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> Organizers { get; set; }
        
        /// <summary>
        /// Location of the conference
        /// </summary>
        /// <returns></returns>
        public Address Location { get; set; }
        
        /// <summary>
        /// External conference website
        /// </summary>
        /// <returns></returns>
        public string SiteUri { get; set; }
        
        /// <summary>
        /// Twitter handle for conference
        /// </summary>
        /// <returns></returns>
        public string TwitterHandle { get; set; }
        
        /// <summary>
        /// Facebook page for conference
        /// </summary>
        /// <returns></returns>
        public string FacebookPage { get; set; }
        
        /// <summary>
        /// Date the this record was created
        /// </summary>
        /// <returns></returns>
        public DateTime CreatedAt { get; set; }
        
        /// <summary>
        /// Last date and time that this record was modified
        /// </summary>
        /// <returns></returns>
        public DateTime ModifiedAt { get; set; }
        
        /// <summary>
        /// Identity of the last person to update this record
        /// </summary>
        /// <returns></returns>
        public string ModifiedBy { get; set; }
    }
}