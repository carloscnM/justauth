using System.Collections.Generic;
using justauth.src.Models;

namespace justauth.src.Domain.Commands.Responses
{
    public class BaseResponse 
    {
        public BaseResponse()
        {
            Errors = new List<string>();
        }
        public int StatusCode { get; protected set; }
        public List<string> Errors { get; protected set; }
    }

    
}