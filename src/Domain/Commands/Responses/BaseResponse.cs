using System.Collections.Generic;
using System.Linq;
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
        public string Status { get {return Errors.Any() ? "Error" : "Sucesso";}}
        public List<string> Errors { get; protected set; }

        public void AddError(string description)
        {
            Errors.Add(description);
        }
    }

    
}