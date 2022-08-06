using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCollection
{
    internal class Initializer : CreateDatabaseIfNotExists<MusicCollectionDbContext>
    {
        protected override void Seed(MusicCollectionDbContext context)
        {
            base.Seed(context);

            context.Clients.Add(new Client()
            {
                Login = "Vlad",
                Password = "Krasava",
            });

            context.Clients.Add(new Client()
            {
                Login = "AndriyGavnokoder",
                Password = "GavnkodKakSmislDshizi",
            });

            context.Clients.Add(new Client()
            {
                Login = "Valentuna",
                Password = "Sobaka",
            });

            context.Clients.Add(new Client()
            {
                Login = "Demien",
                Password = "ProstoDemien",
            });
           
            context.Clients.Add(new Client()
            {
                Login = "Victor",
                Password = "Poshilou",
            });
            context.Clients.Add(new Client()
            {
                Login = "Vitya",
                Password = "Poshilou",
            });
          
          
            context.Countries.Add(new Country()
            {
                Id = 1,

                Name = "Ukraine",
            });
            context.Styles.Add(new Style()
            {
                Id = 1,
                Name = "gavno",
            }); 
            context.Publishers.Add(new Publisher()
            {
                Name = "Vitya",
                CountryId = 1,
            });
            context.Groups.Add(new Group()
            {
                Id = 1,

                StyleId = 1,
                Name = "ESHKEREEEEE",

                Contacts = "fuck you",
                FoundationDate = new DateTime(2019, 01, 29),
                CountryId = 1,
                Rating = 9,
            });
            context.Singers.Add(new Singer()
            {
                Id = 1,

                Surname = "Tagirovich",
                Name = "Alisher",
                BirthDate = new DateTime(2019, 01, 29),
                CountryId = 1,
                GroupId = 1,
            });
            context.Discs.Add(new Disc()
            {
                Id = 1,

                Name = "Pil' ebanaya",
                GroupId = 1,
                PublisherId = 1,
                Price = 300,
                StyleId = 1,
                Rating = 1,
            });
            context.Songs.Add(new Song()
            {
                Id = 1,

                Name = "POSOSI",
                StyleId = 1,
                DiscId = 1,
                Rating = 2,
            });
            context.SaveChanges();
        }
    }
}
