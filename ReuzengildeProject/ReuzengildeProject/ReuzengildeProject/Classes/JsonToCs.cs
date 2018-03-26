using System;
using System.Collections.Generic;
using System.Text;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace ReuzengildeProject.Classes
{
    public partial class JsonToCs
    {
        [JsonProperty("reus")]
        public List<Reus> Reus { get; set; }
    }

    public partial class Reus
    {
        [JsonProperty("Information")]
        public Information Information { get; set; }

        [JsonProperty("Name")]
        public Information Name { get; set; }
    }

    public partial class Information
    {
        [JsonProperty("Text")]
        public string Text { get; set; }
    }

    public partial class JsonToCs
    {
        public static JsonToCs FromJson(string json) => JsonConvert.DeserializeObject<JsonToCs>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this JsonToCs self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
