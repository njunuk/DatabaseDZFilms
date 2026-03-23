using DatabaseDZFilms;
using DatabaseDZFilms.Entities;
using System.Security.Cryptography.X509Certificates;

class Program
{
    AppDbContext db = new AppDbContext();
    public void Main()
    {
        User x = new User();
        Console.Write("User: ");
        x.username = Console.ReadLine();
        Console.Write("Email: ");
        x.email  = Console.ReadLine();
        Console.Write("Password: ");
        x.password  = Console.ReadLine();
        foreach(Film xf in db.Films)
        {
            xf.ToString();
        }
        while (true)
        {
            Console.Write("Input the int of film u want to add to this user, -1 to quit: ");
            int ch = int.Parse(Console.ReadLine());
            if (ch == -1)
            {
                break;
            }
            else
            {
                Film ex = db.Films.Find(ch);
                x.films.Add(ex);
            }
        }
    }
}