using System.Collections.Generic;
using System.Linq;


namespace justauth.src.Domain.Shared.Responses
{
    public class BaseResponse 
    {
        public BaseResponse()
        {
            Errors = new List<string>();
        }

        public bool Success { get {return Errors.Any() ? false : true;}}
        public List<string> Errors { get; protected set; }

        public void AddError(string description)
        {
            Errors.Add(description);
        }
    }

    
}