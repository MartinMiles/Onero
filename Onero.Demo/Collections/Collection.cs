using System.Collections.Generic;
using Onero.Demo.Collections.Inerfaces;
using Onero.Helper.License;

namespace Onero.Demo.Collections
{
    public class Collection : ICollection
    { 
        private static readonly object SyncRoot = new object();
        private static Collection _instance;
        readonly ICollectionRepository _collectionRepository;

        private Collection(ICollectionRepository collectionRepository)
        {
            _collectionRepository = collectionRepository;

            InitAll();
        }

        public static Collection GetInstance(ICollectionRepository collectionRepository)
        {
            if (_instance == null)
            {
                lock (SyncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new Collection(collectionRepository);
                    }
                }
            }

            return _instance;
        }

        public List<License> Licenses { get; set; }


        private void InitAll()
        {
            Licenses = _collectionRepository.ReadLicenses();
        }

        public void SaveLicenses()
        {
            _collectionRepository.SaveLicenses(Licenses);
        }
    }
}