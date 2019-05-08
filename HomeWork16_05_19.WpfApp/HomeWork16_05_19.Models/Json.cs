using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork16_05_19.Models
{
    public class Json
    {
        [JsonProperty("location")]
        public Location Location { get; set; }
        [JsonProperty("current")]
        public Current  Current{ get; set; }
        [JsonProperty("forecast")]
        public Forecast Forecast { get; set; }
    }
}
