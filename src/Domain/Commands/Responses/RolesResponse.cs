using System;
using justauth.src.Domain.Shared.Responses;

namespace justauth.src.Domain.Commands.Responses
{
    public class RolesResponse : BaseResponse
    {
        
        public RolesResponse(string descriptionError)
        {
            Errors.Add(descriptionError);
        }
        public RolesResponse()
        {

        }

        public Guid  Id { get; private set; }
        public string Name { get; private set; }
       
    }
}