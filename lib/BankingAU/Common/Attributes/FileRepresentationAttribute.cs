using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.AU.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class FileRepresentationAttribute : Attribute
    {
        public string Representation { get; private set; }
        public FileRepresentationAttribute(string representation)
        {
            Representation = representation;
        }
    }
}
