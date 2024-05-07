using System.Text.Json.Serialization;

namespace GrapherForm.Models
{
    public class MusicToReview
    {
        [JsonPropertyName("i")]
        public string ID { get; set; }

        [JsonPropertyName("r")]
        public string ArtistName { get; set; }

        [JsonPropertyName("l")]
        public string AlbumName { get; set; }
    }
}
