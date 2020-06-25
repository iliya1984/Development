﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoltTest.Core.Interfaces
{
    public interface IHtmlWebHelper
    {
        Task<HtmlDocument> LoadFromWebAsync(string url);
    }
}
