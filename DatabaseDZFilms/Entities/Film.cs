namespace DatabaseDZFilms.Entities
{
    public class Film
    {
        int id { get; set; }
        string name { get; set; }
        int year { get; set; }
        string description { get; set; }
        User user { get; set; }
        DateTime dateadded { get; set; }
    }
}