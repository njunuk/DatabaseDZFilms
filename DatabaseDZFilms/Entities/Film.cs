namespace DatabaseDZFilms.Entities
{
    public class Film
    {
        int id { get; set; }
        public string name { get; set; }
        int year { get; set; }
        string description { get; set; }
        User user { get; set; }
        DateTime dateadded { get; set; }
        public override string ToString()
        {
            return $"{id}. {name}. {year}. {description}.";
        }
    }
}