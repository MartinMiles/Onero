using System.Xml.Linq;

namespace Onero.Loader.Interfaces
{
    public interface INameable 
    {
        string Name { get; set; }
        
        bool Enabled { get; set; }

        XElement Save();
    }
}
