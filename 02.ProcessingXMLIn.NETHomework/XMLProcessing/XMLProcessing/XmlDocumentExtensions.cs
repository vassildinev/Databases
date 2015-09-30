namespace XmlProcessing
{
    using System.Xml;
    using System.Xml.Linq;

    public static class XmlDocumentExtensions
    {
        public static XDocument ToXDocument(this XmlDocument xmlDocument)
        {
            using (var nodeReader = new XmlNodeReader(xmlDocument))
            {
                nodeReader.MoveToContent();
                return XDocument.Load(nodeReader);
            }
        }
    }
}
