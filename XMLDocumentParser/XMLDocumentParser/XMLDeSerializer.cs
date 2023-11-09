using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml;

namespace XMLDocumentParser
{
    public class XMLDeSerializer<T> : IXMLDeSerializer<T> where T : class
    {
        public async Task<T> Deserialize(string xmlFilePath)
        {
            T data = null;
            try
            {
                await Task.Run(() =>
                {
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load(xmlFilePath);
                    XDocument xDocument = new XDocument();
                    xDocument = XDocument.Parse(xmlDocument.OuterXml);

                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

                    using (XmlReader xmlReader = xDocument.CreateReader())
                    {
                        data = (T)xmlSerializer.Deserialize(xmlReader);
                    }
                }).ConfigureAwait(false);
               
            }
            catch (Exception)
            {
            }
           
            return data;
        }
    }
}