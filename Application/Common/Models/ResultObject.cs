using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class ResultObject<T>  
    {
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }
        public bool IsSuccess
        {
            get
            {
                if (Errors != null)
                {
                    return false;
                }
                return true;
            }
        }            
    }
}
