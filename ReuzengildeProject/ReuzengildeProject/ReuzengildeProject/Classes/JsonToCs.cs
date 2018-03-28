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
        [JsonProperty("deelnemers")]
        public List<Deelnemer> Deelnemers { get; set; }
    }

    public partial class Deelnemer
    {
        [JsonProperty("beschrijving")]
        public string Beschrijving { get; set; }

        [JsonProperty("naam")]
        public string Naam { get; set; }
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
