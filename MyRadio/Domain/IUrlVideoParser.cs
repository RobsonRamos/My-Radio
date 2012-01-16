using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyRadio.Domain
{
    public interface IUrlVideoParser
    {
        string Parse(string url);
    }
}