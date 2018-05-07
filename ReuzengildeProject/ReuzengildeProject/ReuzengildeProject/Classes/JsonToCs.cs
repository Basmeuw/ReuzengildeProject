using System.Collections.Generic;
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

        [JsonProperty("bestandnaam")]
        public string Bestandnaam { get; set; }

        [JsonProperty("naam")]
        public string Naam { get; set; }
    }

    public partial class JsonToCs
    {
        public static JsonToCs FromJson(string json) => JsonConvert.DeserializeObject<JsonToCs>(json);
    }
}
