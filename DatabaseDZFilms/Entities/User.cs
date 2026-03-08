namespace DatabaseDZFilms.Entities
{
    public class User
    {
        int id { get; set; }
        string username { get; set; }
        string email { get; set; }
        string password { get; set; }
        List<Film> films { get; set; }
    }
}