using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Dapper;

namespace MusicCollection
{
    class Program
    {
        public static Check Login(string connStr)
        {
            string login;
            string password;
            Check log;
            log.isLogined = false;
            log.login = "";
            int attempts = 3;
            log.sum = 0;
            do
            {
                Console.Write("Enter login: ");
                login = Console.ReadLine();
                Console.Write("Enter pasword: ");
                password = Console.ReadLine();

                using (IDbConnection db = new SqlConnection(connStr))
                {
                    var res = db.Query<Client>("SELECT * FROM Clients WHERE login = @login AND password = @password", new { login, password }).FirstOrDefault();
                    if (res == null)
                    {
                        attempts -= 1;
                        Console.Clear();
                        Console.WriteLine($"Yo entered wrong login or password. You have {attempts} to login");
                    }
                    if (attempts == 0)
                    {
                        Console.Clear();
                        Console.WriteLine($"10 niggers are coming for u");
                        Environment.Exit(0);
                    }
                    if (res == null && attempts > 0)
                        continue;
                    else
                    {
                        log.login = login;
                        log.isLogined = true;
                        log.sum = res.TotalSum;
                    }

                }
            } while (!log.isLogined);
            Console.Clear();
            return log;
        }
        public static void Menu(Check log, string connStr)
        {
            int choise = 0;
            Console.WriteLine($"WelCUM dear {log.login}");
            Console.WriteLine($"What u want to do?");
            while (true)
            {
                Console.WriteLine($"1: buy the disc");
                Console.WriteLine($"2: find the disc");
                Console.WriteLine($"3: Most popular disc");
                Console.WriteLine($"4: Most popular song");
                Console.WriteLine($"5: Search singer by country");
                Console.WriteLine($"0: Exit");
                choise = Int16.Parse(Console.ReadLine());
                Console.Clear();
                switch (choise)
                {
                    case 1:
                        Buy(log, connStr);
                        break;
                    case 2:
                        Find(connStr);
                        break;
                    case 3:
                        SortByRatingDisc(connStr);
                        break;
                    case 4:
                        SortByRatingSong(connStr);
                        break;
                    case 5:
                        SearchByCountry(connStr);
                        break;
                    case 0:
                        Exit(log, connStr);
                        break;
                    default:
                        break;
                }
            }
        }
        public static void Exit(Check log, string connStr)
        {
            UnitOfWork unit = new UnitOfWork();
            using (IDbConnection db = new SqlConnection(connStr))
            {
                var res = db.Query<Client>("SELECT * FROM Clients  WHERE Login = @login", new { log.login }).FirstOrDefault();
                if (log.sum > 5000)
                    res.TotalSum += log.sum - log.sum / 10;
                else
                    res.TotalSum += log.sum;
                unit.Save();
                Environment.Exit(0);
            }
        }
        static void Buy(Check log, string connStr)
        {
            using (IDbConnection db = new SqlConnection(connStr))
            {
                var res = db.Query<Disc>("SELECT * FROM Discs");
                var res2 = db.Query<Disc>("SELECT * FROM Songs");

                foreach (var item in res)
                {
                    Console.WriteLine($"Name: { item.Name}");
                }
                foreach (var item2 in res2)
                {
                    Console.WriteLine($"Name of song: { item2.Name}");
                    Console.WriteLine($"Rating: { item2.Rating}");
                }
                foreach (var item in res)
                {
                    Console.WriteLine($"price: {item.Price}");
                }
                Console.Write("Which disk u want buy: ");
                int numb = int.Parse(Console.ReadLine());
                int counter = 0;
                foreach (var item in res)
                {
                    if (item.Id == numb)
                    {
                        log.sum += item.Price;
                        counter++;
                    }
                }
                if (counter == 0)
                    Console.WriteLine("You entered wrong number");
            }
        }
        static void SortByRatingDisc(string connStr)
        {
            using (IDbConnection db = new SqlConnection(connStr))
            {

                var res = db.Query<Disc>("SELECT * FROM Discs ORDER BY Rating DESC").FirstOrDefault();
                var res2 = db.Query<Disc>("SELECT * FROM Songs");
                if (res == null)
                {
                    Console.WriteLine($"You entered wrong value");
                    return;
                }
                Console.WriteLine($"Name: { res.Name}");
                foreach (var item2 in res2)
                {
                    Console.WriteLine($"Name of song: { item2.Name}");
                    Console.WriteLine($"Rating: { item2.Rating}");
                }
                Console.WriteLine($"price: {res.Price}");
            }
        }
        static void SearchByCountry(string connStr)
        {
            using (IDbConnection db = new SqlConnection(connStr))
            {
                UnitOfWork unitOfWork = new UnitOfWork();
                Console.Write("Enter country: ");
                string country = Console.ReadLine();
                var res = unitOfWork.SingerRepository.Get(s => s.Country.Name.ToLower() == country.ToLower());
                if (res == null)
                {
                    Console.WriteLine($"You entered wrong value");
                    return;
                }
                foreach (Singer item in res)
                {
                    Console.WriteLine($"Name: {item.Name}");
                    Console.WriteLine($"Date of birth: {item.BirthDate}");
                    Console.WriteLine($"Surname {item.Surname}");
                }
            }
        }
        static void SortByRatingSong(string connStr)
        {
            using (IDbConnection db = new SqlConnection(connStr))
            {
                var res = db.Query<Disc>("SELECT * FROM Songs ORDER BY Rating DESC").FirstOrDefault();
                if (res == null)
                {
                    Console.WriteLine($"You entered wrong value");
                    return;
                }
                Console.WriteLine($"Name: { res.Name}");
                Console.WriteLine($"Rating: { res.Rating}");
            }
        }
        static void Find(string connStr)
        {
            string name;
            Console.Write("Enter disk name: ");
            name = Console.ReadLine();
            using (IDbConnection db = new SqlConnection(connStr))
            {
                var res = db.Query<Disc>("SELECT * FROM Discs WHERE Name = @name", new { name }).FirstOrDefault();
                var res2 = db.Query<Disc>("SELECT * FROM Songs");
                if (res == null)
                {
                    Console.WriteLine($"You entered wrong value");
                    return;

                }
                Console.WriteLine($"Name: { res.Name}");
                foreach (var item2 in res2)
                {
                    Console.WriteLine($"Name of song: { item2.Name}");
                    Console.WriteLine($"Rating: { item2.Rating}");
                }
                Console.WriteLine($"price: {res.Price}");

            }
        }
        public struct Check
        {
            public bool isLogined;
            public string login;
            public int sum;
        }
        static void Main(string[] args)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MusicShop"].ConnectionString;
            UnitOfWork unitOfWork = new UnitOfWork();
            Check data = Login(connStr);
            Menu(data, connStr);
        }

    }
}
