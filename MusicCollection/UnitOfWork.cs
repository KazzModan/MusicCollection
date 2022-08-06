using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCollection
{
    public class UnitOfWork : IDisposable
    {
        private MusicCollectionDbContext context = new MusicCollectionDbContext();
        private GenericRepository<Song> songRepository;
        private GenericRepository<Group> groupRepository;
        private GenericRepository<Style> styleRepository;
        private GenericRepository<Singer> singerRepository;
        private GenericRepository<Publisher> publisherRepository;
        private GenericRepository<Country> countryRepository;
        private GenericRepository<Disc> discRepository;
        private GenericRepository<Client> clientRepository;

        public GenericRepository<Song> SongRepository
        {
            get
            {
                if (songRepository == null)
                    songRepository = new GenericRepository<Song>(context);
                return songRepository;
            }
        }
        public GenericRepository<Singer> SingerRepository
        {
            get
            {
                if (singerRepository == null)
                    singerRepository = new GenericRepository<Singer>(context);
                return singerRepository;
            }
        }
        public GenericRepository<Publisher> PublisherRepository
        {
            get
            {
                if (publisherRepository == null)
                    publisherRepository = new GenericRepository<Publisher>(context);
                return publisherRepository;
            }
        }
        public GenericRepository<Disc> DiscRepository
        {
            get
            {
                if (discRepository == null)
                    discRepository = new GenericRepository<Disc>(context);
                return discRepository;
            }
        }
        public GenericRepository<Style> StyleRepository
        {
            get
            {
                if (styleRepository == null)
                    styleRepository = new GenericRepository<Style>(context);
                return styleRepository;
            }
        }
        public GenericRepository<Client> ClientRepository
        {
            get
            {
                if (clientRepository == null)
                    clientRepository = new GenericRepository<Client>(context);
                return clientRepository;
            }
        }
        public GenericRepository<Group> GroupRepository
        {
            get
            {
                if (groupRepository == null)
                    groupRepository = new GenericRepository<Group>(context);
                return groupRepository;
            }
        }
        public GenericRepository<Country> CountryRepository
        {
            get
            {
                if (countryRepository == null)
                    countryRepository = new GenericRepository<Country>(context);
                return countryRepository;
            }
        }
        


        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
