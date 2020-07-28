using System;
using System.Collections.Generic;
using justauth.src.Models;

namespace justauth.src.Domain.Commands.Responses
{
    public class UserResponse : BaseResponse
    {
        public UserResponse(string email, string token, DateTime expiration)
        {
            Email = email;
            Token = token;
            Expiration = expiration;
        }

        public UserResponse(int statusCode, string descriptionError)
        {
            base.StatusCode = statusCode;
            Errors.Add(descriptionError);
        }

        public UserResponse(int statusCode, List<string> Errors)
        {
            base.StatusCode = statusCode;
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