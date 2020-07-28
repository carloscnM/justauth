using System;
using System.Collections.Generic;


namespace justauth.src.Domain.Commands.Responses
{
    public class RolesResponse : BaseResponse
    {
        
        public RolesResponse(int statusCode, string descriptionError)
        {
            base.StatusCode = statusCode;
            Errors.Add(descriptionError);
        }
        public RolesResponse()
        {

        }

        public Guid  Id { get; private set; }
        public string Name { get; private set; }
       
    }
}