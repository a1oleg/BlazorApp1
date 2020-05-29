using System.Collections.Generic;

namespace BlazorApp1.Data
{
    public class ValueResponse
    {
        public List<string>  Values { get; set; }
        public List<string> Dirs { get; set; }

        
    }

    public class Dir
    {
        public string name { get; set; }
        public string description { get; set; }

        public List<string> Values { get; set; }
    }
}
