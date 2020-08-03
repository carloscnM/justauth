using System;
using System.Collections.Generic;
using justauth.src.Domain.Shared.Responses;

namespace justauth.src.Models.Responses.Users
{
    public class UserResponse : BaseResponse
    {
        public UserResponse(string email, string token, DateTime expiration)
        {
            Email = email;
            Token = token;
            Expiration = expiration;
        }

        public UserResponse(string descriptionError)
        {
            Errors.Add(descriptionError);
        }

        public UserResponse(List<string> Errors)
        {
            Errors.AddRange(Errors);
        }

        public UserResponse()
        {

        }

        public string  Email { get; private set; }
        public string Token { get; private set; }
        public string Type { get; private set;} = "bearer";
        public DateTime Expiration { get; private set; }
    }
}