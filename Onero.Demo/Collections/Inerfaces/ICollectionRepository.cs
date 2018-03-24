using System.Collections.Generic;
using Onero.Helper.License;

namespace Onero.Demo.Collections.Inerfaces
{
    public interface ICollectionRepository
    {
        List<License> ReadLicenses();

        void SaveLicenses(List<License> Licenses);
    }
}