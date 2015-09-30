namespace XmlProcessing
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Schema;
    using System.Xml.Xsl;

    public class EntryPoint
    {
        public static void Main()
        {
            XmlDocument doc = new XmlDocument();
            string filename = "../../catalog.xml";
            doc.Load(filename);

            XmlNodeList nodes = LoadNodesStandard(doc);
            //XmlNodeList nodes = LoadNodesUsingXPath(doc);

            Console.WriteLine(value: "Album artists:");
            Console.WriteLine(new string(c: '=', count: 40));
            RenderAlbumArtists(nodes);

            // Remove expensive albums
            IEnumerable<XmlNode> expensiveAlbums = from XmlNode node in nodes
                                                   where int.Parse(node["price"].InnerText) > 20
                                                   select node;

            foreach (XmlNode album in expensiveAlbums)
            {
                doc.DocumentElement.RemoveChild(album);
            }

            doc.Save(filename);

            Console.WriteLine(value: "\nAfter removal of expensive albums:");
            Console.WriteLine(new string(c: '=', count: 40));
            RenderAlbumArtists(LoadNodesUsingXPath(doc));

            // Album songs
            Console.WriteLine(value: "\nAlbum songs:");
            Console.WriteLine(new string(c: '=', count: 40));
            using (XmlReader reader = XmlReader.Create(filename))
            {
                while (reader.Read())
                {
                    if (reader.Name == "title")
                    {
                        Console.WriteLine(reader.ReadInnerXml());
                    }
                }
            }

            // Album songs using LINQ
            Console.WriteLine(value: "\nAlbum songs using LINQ:");
            Console.WriteLine(new string(c: '=', count: 40));
            IEnumerable<string> titles = from XmlNode node in nodes
                                         from XmlNode x in node["songs"]
                                         select x["title"].InnerText;

            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }

            // Read person.txt and create person.xml
            string[] personData = File.ReadAllText(path: "../../person.txt").Split(separator: new char[] { '\n' });
            var root =
                new XElement(name: "person",
                             content: new object[]
                             {
                                new XElement(name: "name", content: personData[0]),
                                new XElement(name: "address", content: personData[1]),
                                new XElement(name: "phone", content: personData[2])
                             });

            using (XmlWriter writer = XmlWriter.Create(outputFileName: "../../person.xml"))
            {
                root.WriteTo(writer);
            }

            Console.WriteLine(value: "\nperson.xml created successfully:");
            Console.WriteLine(new string(c: '=', count: 40));

            // Write to albums.xml
            var totalAlbums = new XElement("albums");
            using (XmlReader reader = XmlReader.Create(filename))
            {
                using (XmlWriter writer = XmlWriter.Create(outputFileName: "../../albums.xml"))
                {
                    while (reader.Read())
                    {
                        if (reader.Name == "album")
                        {
                            XmlNode albumNode = doc.ReadNode(reader);
                            totalAlbums.Add(new XElement(name: "album", 
                                content: new object[]
                                {
                                    new object[]
                                    {
                                        new XElement(name: "name", content: albumNode["name"].InnerText),
                                        new XElement(name: "artist", content: albumNode["artist"].InnerText)
                                    }
                                }));
                        }
                    }

                    totalAlbums.WriteTo(writer);
                }
            }

            Console.WriteLine(value: "\nalbums.xml created - filtered the albums info");
            Console.WriteLine(new string(c: '=', count: 40));

            // Iterate through the project dir

            var dirPath = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "\\..\\..\\");
            var projectRoot = new XElement(name: "dir",
                                    content: new object[]
                                    {
                                        new XAttribute(name: "type", value: "root"),
                                        new XAttribute(name: "name", value: dirPath.Name)
                                    });

            XElement result = WalkDirectoryTree(dirPath, root);

            using (XmlWriter writer = XmlWriter.Create(outputFileName: "../../directories.xml"))
            {
                result.WriteTo(writer);
            }

            Console.WriteLine(value: "\ndirectories.xml created - iterated through project dir");
            Console.WriteLine(new string(c: '=', count: 40));

            // Extract albums prices < 5 years ago
            Console.WriteLine(value: "\nAlbums prices < 5 years ago using xPath");
            Console.WriteLine(new string(c: '=', count: 40));
            XmlNodeList albums = LoadNodesUsingXPath(doc);

            int currentYear = DateTime.Now.Year;
            foreach (XmlNode node in albums)
            {
                if (currentYear - int.Parse(node["year"].InnerText) <= 5)
                {
                    Console.WriteLine($"{node["name"].InnerText} - {node["year"].InnerText}");
                }
            }

            Console.WriteLine(value: "\nAlbums prices < 5 years ago using LINQ");
            Console.WriteLine(new string(c: '=', count: 40));
            (from XmlNode node in doc.DocumentElement.ChildNodes
             where currentYear - int.Parse(node["year"].InnerText) <= 5
             select node)
             .ToList()
             .ForEach((n) => Console.WriteLine($"{n["name"].InnerText} - {n["year"].InnerText}"));

            // Apply xslt styles
            var transformer = new XslCompiledTransform();
            transformer.Load(stylesheetUri: "../../catalog.xslt");
            transformer.Transform(filename, resultsFile: "../../catalog.html");

            Console.WriteLine(value: "\ncatalog.html created - XSLT styles applied");
            Console.WriteLine(new string(c: '=', count: 40));

            // xsd against xml validation
            Console.WriteLine(value: "\nxsd against xml validation");
            Console.WriteLine(new string(c: '=', count: 40));

            string xsdMarkup = File.ReadAllText(path: "../../catalog.xsd");
            var schemas = new XmlSchemaSet();
            schemas.Add(targetNamespace: "", schemaDocument: XmlReader.Create(new StringReader(xsdMarkup)));

            Console.WriteLine(value: "Validating catalog.xml");
            bool error = false;
            doc.ToXDocument().Validate(schemas, (o, e) =>
            {
                Console.WriteLine(format: "{0}", arg0: e.Message);
                error = true;
            });
            Console.WriteLine(error ? "not successful" : "successful");

            Console.WriteLine(value: "Validating an empty xml document");
            error = false;
            new XDocument(
                new XElement(name: "Root",
                content: new object[]
                {
                    new XElement(name: "Child1", content: "content1"),
                    new XElement(name: "Child2", content: "content2")
                }))
                    .Validate(schemas, (o, e) =>
                    {
                        Console.WriteLine(format: "{0}", arg0: e.Message);
                        error = true;
                    });

            Console.WriteLine(error ? "not successful" : "successful");
        }

        public static XmlNodeList LoadNodesStandard(XmlDocument doc)
        {
            XmlNodeList childNodes = doc.DocumentElement.ChildNodes;
            return childNodes;
        }

        public static XmlNodeList LoadNodesUsingXPath(XmlDocument doc)
        {
            string xPath = "/catalog/album";
            XmlNodeList childNodes = doc.SelectNodes(xPath);
            return childNodes;
        }

        private static void RenderAlbumArtists(XmlNodeList nodes)
        {
            foreach (XmlNode node in nodes)
            {
                Console.WriteLine(node["artist"].InnerText);
            }
        }

        // Source: MSDN
        private static XElement WalkDirectoryTree(DirectoryInfo root, XElement destination)
        {
            FileInfo[] files = null;
            DirectoryInfo[] subDirs = null;

            // First, process all the files directly under this folder
            try
            {
                files = root.GetFiles(searchPattern: "*.*");
            }
            // This is thrown if even one of the files requires permissions greater
            // than the application provides.
            catch (UnauthorizedAccessException e)
            {
                // This code just writes out the message and continues to recurse.
                // You may decide to do something different here. For example, you
                // can try to elevate your privileges and access the file again.
                Console.WriteLine(e.Message);
            }

            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            if (files != null)
            {
                foreach (FileInfo fi in files)
                {
                    destination.Add(new XElement(name: "file", content: fi.Name));
                }

                subDirs = root.GetDirectories();

                foreach (DirectoryInfo dirInfo in subDirs)
                {
                    var subRoot = new XElement(name: "dir",
                                               content: new object[]
                                               {
                                                   new XAttribute(name: "type", value: "subdir"),
                                                   new XAttribute(name: "name", value: dirInfo.Name)
                                               });

                    destination.Add(subRoot);

                    WalkDirectoryTree(dirInfo, subRoot);
                }
            }

            return destination;
        }
    }
}
