using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace MyRadio.Domain
{
    public class YoutubeVideoParser : IUrlVideoParser
    {
        public string Parse(string url)
        {
            string html = "";
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            TextReader reader = new StreamReader(response.GetResponseStream());
            string line;
            bool tagFound = false;
            while ((line = reader.ReadLine()) != null)
            {

                //if(line.Contains("<object "))
                //{
                //    tagFound = true;
                    
                //}
                //if (tagFound)
                //{
                //    html += line; 
                //}
                //if (line.Contains("</object>"))
                //{
                //    tagFound = false;
                //}
                html += line; 
            }
            return html;
        }
    }
}