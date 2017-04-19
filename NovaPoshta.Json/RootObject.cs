using System.Collections.Generic;

namespace NovaPoshta.Json
{
    public class RootObject<T>
    {
        public bool success { get; set; }
        public List<T> data { get; set; }
        public List<object> errors { get; set; }
        public List<object> warnings { get; set; }
        public List<object> info { get; set; }
        public List<object> errorCodes { get; set; }
        public List<object> infoCodes { get; set; }
        public List<object> messageCodes { get; set; }
        public List<object> warningCodes { get; set; }

    }

}
