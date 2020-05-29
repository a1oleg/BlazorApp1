using System.Collections.Generic;

namespace BlazorApp1.Data
{
    public class PersonAndFilmsResponse
    {
        public PersonContent Person { get; set; }

        public class PersonContent
        {
            public string Name { get; set; }

            public FilmConnectionContent FilmConnection { get; set; }

            public class FilmConnectionContent
            {
                public List<FilmContent> Films { get; set; }

                public class FilmContent
                {
                    public string Title { get; set; }
                }
            }
        }
    }
}