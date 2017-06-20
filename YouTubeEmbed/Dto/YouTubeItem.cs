using System;
using System.Collections.Generic;
using Humanizer;

namespace YouTubeEmbed.Models
{
    public class YouTubeItem
    {
        public string VideoId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string DescriptionShort
        {
            get
            {
                if (Description.Length <= 150)
                    return Description;

                return Description.Substring(0, 150) + "...";
            }
        }

        public string ChannelTitle { get; set; }

        public string DefaultThumbnailUrl { get; set; }

        public string MediumThumbnailUrl { get; set; }

        public string HighThumbnailUrl { get; set; }

        public string StandardThumbnailUrl { get; set; }

        public string MaxResThumbnailUrl { get; set; }

        public DateTime PublishedAt { get; set; }

        public string PublishedAtHumanized { get { return PublishedAt.Humanize(); } }

        public int? ViewCount { get; set; }

        public int? LikeCount { get; set; }

        public int? DislikeCount { get; set; }

        public int? FavoriteCount { get; set; }

        public int? CommentCount { get; set; }

        public List<string> Tags { get; set; }
    }
}
