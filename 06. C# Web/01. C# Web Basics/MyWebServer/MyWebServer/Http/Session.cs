﻿using MyWebServer.Common;
using System.Collections.Generic;

namespace MyWebServer.Http
{
    public class Session
    {

        public const string SessionCookieName = "MyWebServerSID";

        private Dictionary<string, string> data;
        public Session(string id)
        {
            Guard.AgainstNull(id, nameof(id));
            this.Id = id;
            this.data = new();
        }
        public string Id { get; init; }
        public int Count => this.data.Count;

        public string this[string key]
        {
            get => this.data[key];
            set => this.data[key] = value;
        }
        public bool ContainsKey(string key)
            => this.data.ContainsKey(key);
        public bool IsNew { get; set; }

        public void Remove(string key)
        {
            if (this.data.ContainsKey(key))
            {
                this.data.Remove(key);

            }
        }
    }
}
