using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace KonsumeraAPI
{
    public class GitRepo
    {
        // Properties mapped to JSON fields from GitHub API response

        [JsonPropertyName("name")]
        public string Name { get; set; } = "";

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; set; } = "";

        [JsonPropertyName("homepage")]
        public string? Homepage { get; set; }

        [JsonPropertyName("watchers")]
        public int Watchers { get; set; }

        [JsonPropertyName("pushed_at")]
        public DateTime PushedAt { get; set; }
    }
}
