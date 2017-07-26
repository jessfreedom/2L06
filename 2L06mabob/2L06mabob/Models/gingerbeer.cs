using System;
using Newtonsoft.Json;

namespace L06mabob.Models
{
    public class gingerbeer
    {
		    [JsonProperty(PropertyName = "id")]
		    public string id { get; set; }

			[JsonProperty(PropertyName = "Quote")]
			public string Quote { get; set; }

		    [JsonProperty(PropertyName = "Mood")]
		    public string Mood { get; set; }
		
    }
}

