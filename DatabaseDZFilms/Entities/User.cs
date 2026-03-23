using System.Xml.Linq;

namespace DatabaseDZFilms.Entities
{
    public class User
    {
        int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public List<Film> films { get; set; }
        public override string ToString()
        {
            return $"{id}. {username}. Films: {string.Join(" / ", films.Select(f => f.name))}"; //podannya
        }
    }
}