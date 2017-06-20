using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FreshMvvm;
using Newtonsoft.Json;
using PropertyChanged;
using YouTubeEmbed.Models;

namespace YouTubeEmbed.PageModels
{
    [AddINotifyPropertyChangedInterface]
    public class YouTubeChannelPageModel : FreshBasePageModel
    {
        // Get your API Key @ https://console.developers.google.com/apis/api/youtube/
        const string ApiKey = "AIzaSyB2Hu4D97zOB8f410cwT2rCc6JnmwoLCAo";
        const string ChannelId = "UCoal_hpPIPAnWlG-kWHLheA";

        // Documentation @ https://developers.google.com/apis-explorer/#p/youtube/v3/youtube.videos.list 
        string channelUrl = $"https://www.googleapis.com/youtube/v3/search?part=id&maxResults=20&channelId={ChannelId}&key={ApiKey}";
        string detailsUrl = "https://www.googleapis.com/youtube/v3/videos?part=snippet,statistics&key=" + ApiKey + "&id={0}";

        public List<YouTubeItem> Items { get; set; } = new List<YouTubeItem>();

        public override void Init(object initData)
        {
            base.Init(initData);

            // Retrieve our data.
            Task.Factory.StartNew(GetChannelData);
        }

        async Task GetChannelData()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var videoIds = new List<string>();
                    var json = await httpClient.GetStringAsync(channelUrl);

                    // Deserialize our data, this is in a simple List format
                    var response = JsonConvert.DeserializeObject<YouTubeApiListRoot>(json);

                    // Add all the video id's we've found to our list.
                    videoIds.AddRange(response.items.Select(item => item.id.videoId));

                    // Get the details for all our items
                    Items = await GetVideoDetailsAsync(videoIds);
                }
            }
            catch (Exception ex)
            {
                var ms = ex;
            }
        }

        async Task<List<YouTubeItem>> GetVideoDetailsAsync(List<string> videoIds)
        {
            try
            {
                var videoIdString = string.Join(",", videoIds);
                var youtubeItems = new List<YouTubeItem>();

                using (var httpClient = new HttpClient())
                {
                    var json = await httpClient.GetStringAsync(string.Format(detailsUrl, videoIdString));
                    var response = JsonConvert.DeserializeObject<YouTubeApiDetailsRoot>(json);

                    foreach (var item in response.items)
                    {
                        var youTubeItem = new YouTubeItem()
                        {
                            Title = item.snippet.title,
                            Description = item.snippet.description,
                            ChannelTitle = item.snippet.channelTitle,
                            PublishedAt = item.snippet.publishedAt,
                            VideoId = item.id,
                            DefaultThumbnailUrl = item.snippet?.thumbnails?.@default?.url,
                            MediumThumbnailUrl = item.snippet?.thumbnails?.medium?.url,
                            HighThumbnailUrl = item.snippet?.thumbnails?.high?.url,
                            StandardThumbnailUrl = item.snippet?.thumbnails?.standard?.url,
                            MaxResThumbnailUrl = item.snippet?.thumbnails?.maxres?.url,
                            ViewCount = item.statistics?.viewCount,
                            LikeCount = item.statistics?.likeCount,
                            DislikeCount = item.statistics?.dislikeCount,
                            FavoriteCount = item.statistics?.favoriteCount,
                            CommentCount = item.statistics?.commentCount,
                            Tags = item.snippet?.tags
                        };

                        youtubeItems.Add(youTubeItem);
                    }
                }

                return youtubeItems;
            }
            catch (Exception ex)
            {
                var ms = ex;
                return new List<YouTubeItem>();
            }
        }
    }
}