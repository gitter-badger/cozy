﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CozyMobi.Core.RequestBuilder
{
    class SocialRequestBuilder
    {
        public HttpContent Maopao(string content, string device)
        {
            var v = new Dictionary<string, string>();
            v.Add("content", content);
            v.Add("device", device);
            HttpContent http_content = new FormUrlEncodedContent(v);
            return http_content;
        }

        public HttpContent SendMessage(string name, string content)
        {
            var v = new Dictionary<string, string>();
            v.Add("receiver_global_key", name);
            v.Add("content", content);
            HttpContent http_content = new FormUrlEncodedContent(v);
            return http_content;
        }
    }
}
