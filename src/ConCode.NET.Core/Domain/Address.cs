using System;
namespace ConCode.NET.Core
{
    /// <summary>
    /// Represents and address for the conference or user
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Name of the location
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }
        
        /// <summary>
        /// Address line 1
        /// </summary>
        /// <returns></returns>
        public string Line1 { get; set; }

        /// <summary>
        /// Address line 2
        /// </summary>
        /// <returns></returns>
        public string Line2 { get; set; }

        /// <summary>
        /// Address line 3
        /// </summary>
        /// <returns></returns>
        public string Line3 { get; set; }

        /// <summary>
        /// Address city
        /// </summary>
        /// <returns></returns>
        public string City { get; set; }

        /// <summary>
        /// Address postal code
        /// </summary>
        /// <returns></returns>
        public string PostalCode { get; set; }

        /// <summary>
        /// Address state or province
        /// </summary>
        /// <returns></returns>
        public string StateOrProvince{ get; set; }

        /// <summary>
        /// Address country
        /// </summary>
        /// <returns></returns>
        public string Country { get; set; }
    }
}