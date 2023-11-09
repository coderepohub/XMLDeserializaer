using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLDocumentParser
{
    public interface IXMLDeSerializer<T> where T : class
    {
        /// <summary>
        /// Xml Deserializer to deserialize the xml file
        /// </summary>
        /// <param name="xmlFilePath">Path of the XML File</param>
        /// <returns></returns>
        Task<T> Deserialize(string xmlFilePath);
    }
}
