using System.Collections.Generic;

namespace NovaPoshta.Core
{
    public class RootObject<T>
    {
        public bool success { get; set; }
        public List<T> data { get; set; }
        public List<object> errors { get; set; }
        public List<object> warnings { get; set; }
        public List<object> info { get; set; }
    }

}
