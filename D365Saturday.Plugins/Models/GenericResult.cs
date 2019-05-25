using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D365Saturday.Plugins.Models
{
    public class GenericResult
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }

        public GenericResult()
        {
            Success = true;
        }

        public static GenericResult Error(string errorMessage)
        {
            return new GenericResult() { Success = false, ErrorMessage = errorMessage };
        }
    }

    public class GenericResult<T>: GenericResult
    {
        public T Model { get; set; }
    }

}
