using System.Collections.Generic;

namespace SevannRadhak_03_11_2020.Models
{
    public class RestfulResponse<T> where T : class
    {
        //public bool IsSuccess { get; set; }

        //public string Message { get; set; }

        public List<T> Result { get; set; }
    }
}
