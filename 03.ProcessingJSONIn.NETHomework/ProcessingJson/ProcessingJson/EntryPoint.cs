namespace ProcessingJson
{
    using System;
    using System.Net;
    using System.Xml;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System.Xml.Linq;
    using System.Web.UI;
    using System.IO;

    public class EntryPoint
    {
        public static void Main()
        {
            using (WebClient client = new WebClient())
            {
                Console.OutputEncoding = Encoding.Unicode;
                string fileName = "../../rss.xml";
                //client.DownloadFile(address: "https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw",
                //   fileName: fileName);
                Console.WriteLine(value: "Content downloaded at rss.xml");
                Console.WriteLine(new string(c: '=', count: 40));
                Console.WriteLine();

                var doc = new XmlDocument();
                doc.Load(filename: fileName);

                string jsonText = JsonConvert.SerializeXmlNode(doc);
                JToken json = JObject.Parse(jsonText).Last;

                var videos = new List<Video>();
                foreach (var key in json)
                {
                    foreach (var vid in key["entry"])
                    {
                        var video = new Video()
                        {
                            Title = vid["title"].ToString(),
                            Url = vid["link"]["@href"].ToString()
                        };

                        videos.Add(video);
                    }
                }

                StringWriter stringWriter = new StringWriter();
                using (HtmlTextWriter writer = new HtmlTextWriter(stringWriter))
                {
                    writer.RenderBeginTag(HtmlTextWriterTag.Html);
                    writer.RenderBeginTag(HtmlTextWriterTag.Body);

                    foreach (var item in videos)
                    {
                        writer.AddAttribute("style", "border:1px solid black;border-radius:5px;");
                        writer.RenderBeginTag(HtmlTextWriterTag.Div);

                        writer.RenderBeginTag(HtmlTextWriterTag.H3);
                        writer.Write(item.Title);
                        writer.RenderEndTag();

                        writer.RenderBeginTag(HtmlTextWriterTag.P);
                        writer.AddAttribute("href", item.Url);
                        writer.RenderBeginTag(HtmlTextWriterTag.A);
                        writer.Write("View in YouTube");
                        writer.RenderEndTag();
                        writer.RenderEndTag();

                        writer.RenderBeginTag(HtmlTextWriterTag.P);
                        writer.Write("YouTube does not allow sharing videos directly through iframe - you need an embed code. Therefore, here is Batman to cheer you up");
                        writer.RenderEndTag();

                        writer.AddAttribute("src", "https://www.youtube.com/embed/UgBBitvVHAg");
                        writer.AddAttribute("width", "420px");
                        writer.AddAttribute("height", "315px");
                        writer.AddAttribute("frameborder", "0");
                        writer.RenderBeginTag(HtmlTextWriterTag.Iframe);

                        writer.RenderEndTag();
                        writer.RenderEndTag();
                    }

                    writer.RenderEndTag();
                    writer.RenderEndTag();
                }

                using (StreamWriter writer = new StreamWriter("../../academy.html", false, Encoding.UTF8))
                {
                    writer.WriteLine(stringWriter.ToString());
                }

                Console.WriteLine(value: "Content written at academy.html");
                Console.WriteLine(new string(c: '=', count: 40));
                Console.WriteLine();
            }
        }
    }
}
