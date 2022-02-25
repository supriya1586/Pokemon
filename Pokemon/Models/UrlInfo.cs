using Newtonsoft.Json;
using Pokemon.Models;
using System.Collections.Generic;

namespace Pokemon
{
    public class UrlInfo
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public flavortextentries[] flavor_text_entries { get; set; }

        public habitat habitat { get; set; }

        public bool is_legendary { get; set; }

    }
}
