using System;
using System.Xml;
using System.Xml.Linq;
using Onero.Loader.Interfaces;

namespace Onero.Loader
{
    public class BaseItem : INameable
    {
        public string Name { get; set; }

        public bool Enabled { get; set; }

        protected XmlNode node;

        #region Contructors

        protected BaseItem()
        {
        }

        public BaseItem(XmlNode node)
        {
            this.node = node;

            Parse();
        }

        #endregion

        public virtual XElement Save()
        {
            throw new NotImplementedException("Should be implemened in derived class");
        }

        protected virtual void Parse()
        {
            throw new NotImplementedException("Should be implemened in derived class");
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
