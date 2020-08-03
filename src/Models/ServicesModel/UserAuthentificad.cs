using System;

namespace justauth.src.Models.ServicesModel 
{
    public class ServiceJwtResponse
    {
        public string  Email { get; set; }
        public string Token { get; set; }
        public string Type { get; set; } = "bearer";
        public DateTime Expiration { get; set; }
    }
}