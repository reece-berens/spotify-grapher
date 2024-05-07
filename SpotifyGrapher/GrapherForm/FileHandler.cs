using GrapherForm.Models;
using System.Text.Json;

namespace GrapherForm
{
    public static class FileHandler
    {
        public static EnvironmentG GetEnvironment(string filePath, out Dictionary<string, FoundArtist> foundArtists, out Dictionary<string, FoundArtist> reviewArtists,
            out Dictionary<string, FoundArtist> removedArtists, out Dictionary<string, string> musicFinished, out Dictionary<string, MusicToReview> musicToReview)
        {
            EnvironmentG environment = null;
            foundArtists = null;
            reviewArtists = null;
            removedArtists = null;
            musicFinished = null;
            musicToReview = null;
            if (File.Exists(filePath))
            {
                string text = File.ReadAllText(filePath);
                environment = JsonSerializer.Deserialize<EnvironmentG>(text);

                if (File.Exists(environment.FoundArtistFile))
                {
                    string json = File.ReadAllText(environment.FoundArtistFile);
                    foundArtists = JsonSerializer.Deserialize<Dictionary<string, FoundArtist>>(json);
                }

                if (File.Exists(environment.ArtistReviewFile))
                {
                    string json = File.ReadAllText(environment.ArtistReviewFile);
                    reviewArtists = JsonSerializer.Deserialize<Dictionary<string, FoundArtist>>(json);
                }

                if (File.Exists(environment.RemovedArtistFile))
                {
                    string json = File.ReadAllText(environment.RemovedArtistFile);
                    removedArtists = JsonSerializer.Deserialize<Dictionary<string, FoundArtist>>(json);
                }

                if (File.Exists(environment.MusicFinishedFile))
                {
                    string json = File.ReadAllText(environment.MusicFinishedFile);
                    musicFinished = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
                }

                if (File.Exists(environment.MusicToReviewFile))
                {
                    string json = File.ReadAllText(environment.MusicToReviewFile);
                    musicToReview = JsonSerializer.Deserialize<Dictionary<string, MusicToReview>>(json);
                }
            }
            else
            {
                MessageBox.Show("Environment file path doesn't exist.");
            }
            return environment;
        }

        public static void SaveEnvironment(string environmentPath, EnvironmentG environment, Dictionary<string, FoundArtist> foundArtists, Dictionary<string, FoundArtist> reviewArtists,
            Dictionary<string, FoundArtist> removedArtists, Dictionary<string, string> musicFinished, Dictionary<string, MusicToReview> musicToReview)
        {
            JsonSerializerOptions options = new()
            {
                WriteIndented = true,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
            };

            if (Directory.Exists(Path.GetDirectoryName(environmentPath)) && environment != null)
            {
                string environmentJson = JsonSerializer.Serialize(environment, options);
                File.WriteAllText(environmentPath, environmentJson);

                if (Directory.Exists(Path.GetDirectoryName(environment.FoundArtistFile)) && foundArtists != null)
                {
                    string json = JsonSerializer.Serialize(foundArtists, options);
                    File.WriteAllText(environment.FoundArtistFile, json);
                }

                if (Directory.Exists(Path.GetDirectoryName(environment.ArtistReviewFile)) && reviewArtists != null)
                {
                    string json = JsonSerializer.Serialize(reviewArtists, options);
                    File.WriteAllText(environment.ArtistReviewFile, json);
                }

                if (Directory.Exists(Path.GetDirectoryName(environment.RemovedArtistFile)) && removedArtists != null)
                {
                    string json = JsonSerializer.Serialize(removedArtists, options);
                    File.WriteAllText(environment.RemovedArtistFile, json);
                }

                if (Directory.Exists(Path.GetDirectoryName(environment.MusicFinishedFile)) && musicFinished != null)
                {
                    string json = JsonSerializer.Serialize(musicFinished, options);
                    File.WriteAllText(environment.MusicFinishedFile, json);
                }

                if (Directory.Exists(Path.GetDirectoryName(environment.MusicToReviewFile)) && musicToReview != null)
                {
                    string json = JsonSerializer.Serialize(musicToReview, options);
                    File.WriteAllText(environment.MusicToReviewFile, json);
                }
            }
            else
            {
                MessageBox.Show("Environment is null or path doesn't exist.");
            }
        }
    }
}
