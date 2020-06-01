using System.Collections.Generic;

namespace BlazorApp1.Data
{    
    public class Rootobject
    {
        public Data Data { get; set; }
        public object Errors { get; set; }
        public object Extensions { get; set; }
    }

    public class Data
    {
        //public object Values { get; set; }
        //public List<string> Dirs { get; set; }
        //public List<Dir> Dir { get; set; }
        public Dir Dir { get; set; }
    }
    public class Dir
    {
        public string description { get; set; }
        public List<Value> Values { get; set; }
    }

    public class Value
    {
        public string TXTLG { get; set; }
        public List<Wagon> Wagons { get; set; }
    }
    public class Wagon
    {
        public int _id { get; set; }
        public List<Value> Values { get; set; }
    }

}
