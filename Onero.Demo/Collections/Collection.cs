using System.Collections.Generic;
using Onero.Demo.Collections.Inerfaces;
using Onero.Helper.ErrorHandling;
using Onero.Helper.Feedback;
using Onero.Helper.License;

namespace Onero.Demo.Collections
{
    public class Collection : ICollection
    { 
        private static readonly object SyncRoot = new object();
        private static Collection _instance;
        readonly ICollectionRepository _collectionRepository;

        internal Collection(ICollectionRepository collectionRepository)
        {
            _collectionRepository = collectionRepository;

            InitAll();
        }

        internal static Collection GetInstance(ICollectionRepository collectionRepository)
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
        public List<Feedback> Feedbacks { get; set; }
        public List<ReportableError> ReportableErrors { get; set; }


        private void InitAll()
        {
            Licenses = _collectionRepository.ReadLicenses();
            Feedbacks = _collectionRepository.ReadFeedbacks();
            ReportableErrors = _collectionRepository.ReadReportableErrors();
        }

        public void SaveLicenses()
        {
            _collectionRepository.SaveLicenses(Licenses);
        }
        public void SaveFeedbacks()
        {
            _collectionRepository.SaveFeedbacks(Feedbacks);
        }

        public void SaveReportableErrors()
        {
             _collectionRepository.SaveReportableErrors(ReportableErrors);
        }
    }
}