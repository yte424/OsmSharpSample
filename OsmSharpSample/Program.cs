using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web;
using System.Net;
using System.Xml;
using System.IO;
using OsmSharp.Osm.Data.Processor;
using OsmSharp.Osm.Data.XML.Processor;
using OsmSharp.Osm.Data.XML;
using OsmSharp.Osm.Simple;



namespace OsmSharpSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // create the webrequest.
            WebRequest request = WebRequest.Create(
            "http://overpass.osm.rambler.ru/cgi/interpreter?data=way" +
            "[\"name\"=\"Gielgenstraße\"]" +
            "(50.7,7.1,50.8,7.25);out;");
            request.Method = "GET";
            Stream request_stream = request.GetResponse().GetResponseStream(); // get the data.


            
            // use an XML data processor source.
            XmlDataProcessorSource source = new XmlDataProcessorSource(
            request_stream);

            // pull the data from the stream and deserialize XML.
            ICollection<SimpleOsmGeo> collection = source.PullToCollection();
        }
    }
}
