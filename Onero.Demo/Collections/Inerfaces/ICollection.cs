using System.Collections.Generic;
using Onero.Helper.License;

namespace Onero.Demo.Collections.Inerfaces
{
    public interface ICollection
    {
        List<License> Licenses { get; set; }

        void SaveLicenses();
    }
}