using System;
using Onero.Demo.Collections.Inerfaces;
using Onero.Helper.Feedback;
using Onero.Helper.License;

namespace Onero.Demo.Services
{
    public class FeedbacksService
    {
        private readonly ICollection _collection;
        private readonly LicenseHelper _licenseHelper;

        public FeedbacksService(ICollection collection)
        {
            _collection = collection;
            _licenseHelper = new LicenseHelper();
        }

        public string Send(string firstname, string lastname, string email, string message)
        {
            var feedback = new Feedback {FirstName = firstname, LastName = lastname, Email = email, Message = message, Created = DateTime.Today };

            _collection.Feedbacks.Add(feedback);
            _collection.SaveFeedbacks();

            return feedback.Message;
        }
    }
}