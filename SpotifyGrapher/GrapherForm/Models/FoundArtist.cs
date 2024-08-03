using System.Text.Json.Serialization;

namespace GrapherForm.Models
{
    public class FoundArtist
    {
        [JsonPropertyName("i")]
        public string ID { get; set; }

        [JsonPropertyName("n")]
        public string Name { get; set; }

        [JsonPropertyName("r")]
        public bool RelatedVisited { get; set; }

        [JsonPropertyName("s")]
        public List<string> Genres { get; set; }

        [JsonPropertyName("a")]
        public bool? AlbumsVisited { get; set; }
    }
}
