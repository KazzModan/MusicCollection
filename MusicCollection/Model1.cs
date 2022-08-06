using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCollection
{
    public class MusicCollectionDbContext : DbContext
    {
        public MusicCollectionDbContext()
           : base("name=MusicShop")
        {
            Database.SetInitializer(new Initializer());

        }
        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Disc> Discs { get; set; }

        public virtual DbSet<Group> Groups { get; set; }

        public virtual DbSet<Publisher> Publishers { get; set; }

        public virtual DbSet<Singer> Singers { get; set; }

        public virtual DbSet<Song> Songs { get; set; }

        public virtual DbSet<Style> Styles { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Publisher>().HasRequired(p => p.Country)
                                                     .WithMany(c => c.Publishers)
                                                     .HasForeignKey(p => p.CountryId)
                                                     .WillCascadeOnDelete(false);
            modelBuilder.Entity<Song>().HasRequired(s => s.Style)
                                                   .WithMany(s => s.Songs)
                                                   .HasForeignKey(p => p.StyleId)
                                                   .WillCascadeOnDelete(false);
            modelBuilder.Entity<Song>().HasRequired(s => s.Style)
                                                 .WithMany(s => s.Songs)
                                                 .HasForeignKey(p => p.StyleId)
                                                 .WillCascadeOnDelete(false);
            modelBuilder.Entity<Disc>().HasRequired(d => d.Group)
                                                  .WithMany(g => g.Discs)
                                                  .HasForeignKey(d => d.GroupId)
                                                  .WillCascadeOnDelete(false);
             modelBuilder.Entity<Disc>().HasRequired(d => d.Style)
                                                  .WithMany(s => s.Discs)
                                                  .HasForeignKey(d => d.StyleId)
                                                  .WillCascadeOnDelete(false);
            modelBuilder.Entity<Singer>().HasRequired(s =>s.Group)
                                                 .WithMany(g => g.Singers)
                                                 .HasForeignKey(s => s.GroupId)
                                                 .WillCascadeOnDelete(false);
            modelBuilder.Entity<Group>().HasRequired(s => s.Country)
                                                .WithMany(g => g.Groups)
                                                .HasForeignKey(s => s.CountryId)
                                                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Group>().HasRequired(s => s.Style)
                                             .WithMany(g => g.Groups)
                                             .HasForeignKey(s => s.StyleId)
                                             .WillCascadeOnDelete(false);
        }
    }
}
