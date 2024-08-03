using System.Text.Json.Serialization;

namespace GrapherForm.Models
{
    public class MusicToReview
    {
        [JsonPropertyName("i")]
        public string ID { get; set; }

        [JsonPropertyName("r")]
        public List<MusicToReviewArtist> Artists { get; set; }

        [JsonPropertyName("l")]
        public string AlbumName { get; set; }
    }

    public class MusicToReviewArtist
    {
        [JsonPropertyName("i")]
        public string ID { get; set; }
        [JsonPropertyName("n")]
        public string ArtistName { get; set; }
    }
}
