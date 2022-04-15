using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public class ResponseBase<T>
    {
        public ResponseBase()
        {
            ResponseTime = DateTime.Now;
            Message = "";
            Code = 0;
        }
        public DateTime ResponseTime { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
