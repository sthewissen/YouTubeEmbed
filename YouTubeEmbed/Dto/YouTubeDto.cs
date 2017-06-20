using System;
using System.Collections.Generic;

namespace YouTubeEmbed.Models
{
    public class YouTubeApiListId
    {
        public string kind { get; set; }
        public string videoId { get; set; }
    }

    public class YouTubeApiListItem
    {
        public string kind { get; set; }
        public string etag { get; set; }
        public YouTubeApiListId id { get; set; }
    }

    public class YouTubeApiListRoot
    {
        public string kind { get; set; }
        public string etag { get; set; }
        public string nextPageToken { get; set; }
        public string regionCode { get; set; }
        public List<YouTubeApiListItem> items { get; set; }
    }

    public class Default
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Medium
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class High
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Standard
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Maxres
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Thumbnails
    {
        public Default @default { get; set; }
        public Medium medium { get; set; }
        public High high { get; set; }
        public Standard standard { get; set; }
        public Maxres maxres { get; set; }
    }

    public class Localized
    {
        public string title { get; set; }
        public string description { get; set; }
    }

    public class Snippet
    {
        public DateTime publishedAt { get; set; }
        public string channelId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Thumbnails thumbnails { get; set; }
        public string channelTitle { get; set; }
        public List<string> tags { get; set; }
        public string categoryId { get; set; }
        public string liveBroadcastContent { get; set; }
        public string defaultLanguage { get; set; }
        public Localized localized { get; set; }
        public string defaultAudioLanguage { get; set; }
    }

    public class Statistics
    {
        public int? viewCount { get; set; }
        public int? likeCount { get; set; }
        public int? dislikeCount { get; set; }
        public int? favoriteCount { get; set; }
        public int? commentCount { get; set; }
    }

    public class YouTubeApiDetailsItem
    {
        public string kind { get; set; }
        public string etag { get; set; }
        public string id { get; set; }
        public Snippet snippet { get; set; }
        public Statistics statistics { get; set; }
    }

    public class YouTubeApiDetailsRoot
    {
        public string kind { get; set; }
        public string etag { get; set; }
        public List<YouTubeApiDetailsItem> items { get; set; }
    }
}
