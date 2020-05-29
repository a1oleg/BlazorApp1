using System.Collections.Generic;

namespace BlazorApp1.Data
{
    public class ValueResponse
    {
        public List<string> Values { get; set; }
        public List<string> Dirs { get; set; }


    }

    public class Dir
    {
        public string name { get; set; }
        public string description { get; set; }

        public List<string> Values { get; set; }
    }


    public class Rootobject
    {
        public Data Data { get; set; }
        public object Errors { get; set; }
        public object Extensions { get; set; }
    }

    public class Data
    {
        public object Values { get; set; }
        public string[] Dirs { get; set; }
    }

}
