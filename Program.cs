using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    class Program
    {


        static async Task Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            Console.Write("Введіть пароль: ");
            string password = Console.ReadLine();

           

            await using var db = new AppDbContext();

            await db.Database.EnsureCreatedAsync();
 
            db.Users.Add(new User { UserName = name, Password = password });




            await db.SaveChangesAsync();


            var users = await db.Users
                .OrderBy(u => u.Id)
                .ToListAsync();

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id} - {user.UserName}");
            }

            Console.WriteLine("\nНатисніть будь-яку клавішу...");
            Console.ReadKey();
        }
    }
}
