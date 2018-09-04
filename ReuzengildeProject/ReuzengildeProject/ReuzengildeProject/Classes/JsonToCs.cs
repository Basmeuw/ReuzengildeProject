using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace ReuzengildeProject.Classes
{
    //een class met een list met alle deelnemers 
    public partial class JsonToCs
    {
        [JsonProperty("deelnemers")]
        public List<Deelnemer> Deelnemers { get; set; }
    }
    //de deelnemer class waar een beschrijving, bestandsnaam en naam in staat
    public partial class Deelnemer
    {
        [JsonProperty("beschrijving")]
        public string Beschrijving { get; set; }

        [JsonProperty("bestandnaam")]
        public string Bestandnaam { get; set; }

        [JsonProperty("naam")]
        public string Naam { get; set; }

        [JsonProperty("website")]
        public string Link { get; set; }
    }
    //class die een json file omzet naar c# objecten
    public partial class JsonToCs
    {
        public static JsonToCs FromJson(string json) => JsonConvert.DeserializeObject<JsonToCs>(json);
    }
}
