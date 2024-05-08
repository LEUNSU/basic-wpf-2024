﻿using System.Diagnostics;
using System.Windows;
using System.Windows.Media.Imaging;
using ex10_MovieFinder2024.Models;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using MahApps.Metro.Controls;

namespace ex10_MovieFinder2024
{
    /// <summary>
    /// TralierWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TralierWindow : MetroWindow
    {
        List<YoutubeItem> youtubeitems = null; // 유튜브API 검색결과 담을 객체리스트
        public TralierWindow()
        {
            InitializeComponent();
        }

        // MainWindow 그리드에서 선택된 영화제목 넘기면서 생성
        // 재정의생성자
        public TralierWindow(string movieName) : this()
        {   
            // this() => TrailerWindow() 생성자를 먼저 실행한 뒤 
            LblMovieName.Content = $"{movieName} 예고편";
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            youtubeitems = new List<YoutubeItem>(); // 초기화
            SearchYoutubeApi(); // 핵심메서드 실행
        }

        private async void SearchYoutubeApi()
        {
            await LoadDataCollection(); // 비동기로 유튜브API 실행
            LsvResult.ItemsSource = youtubeitems;

            LsvResult.SelectedIndex = 0; // 맨 첫번째것이 선택
        }

        private async Task LoadDataCollection()
        {
            // YoutubeService용 패키지
            var service = new YouTubeService(
                new BaseClientService.Initializer()
                {
                    ApiKey = "AIzaSyCUb5-RbmBxPTnaeXyjjHzM9vqVk1Frcu8",
                    ApplicationName = this.GetType().ToString()
                });

            var req = service.Search.List("snippet");
            req.Q = LblMovieName.Content.ToString(); // 어벤져스 인피니티 워 예고편
            req.MaxResults = 10;

            var res = await req.ExecuteAsync(); // Youtube 서버에서 요청된 값을 실행하고 결과 리턴(비동기)

            //await this.ShowMessageAsync("검색결과", res.Items.Count.ToString());
            foreach (var item in res.Items)
            {
                if (item.Id.Kind.Equals("youtube#video")) // 동영상플레이 가능한 아이템만
                {
                    var youtube = new YoutubeItem()
                    {
                        Title = item.Snippet.Title,
                        ChannelTitle = item.Snippet.ChannelTitle,
                        URL =$"https://www.youtube.com/watch?v={item.Id.VideoId}", // 유튜브 플레이링크
                        Author = item.Snippet.ChannelId,
                    };

                    youtube.Thumbnail = new BitmapImage(new Uri(item.Snippet.Thumbnails.Default__.Url, UriKind.RelativeOrAbsolute));

                    youtubeitems.Add(youtube);
                }
            }
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // 한번씩 CefSharp 브라우저에서 메모리 릭 발생
            BrsYoutube.Address = string.Empty;
            BrsYoutube.Dispose(); // 종종 앱 종료시 객체를 완전 해제
        }

        private void LsvResult_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (LsvResult.SelectedItem is YoutubeItem) // is => true/false
            {
                var video = LsvResult.SelectedItem as YoutubeItem; // as => casting 실패하면 null
                Debug.WriteLine(video.URL);
                BrsYoutube.Address = video.URL;
            }
        }
    }
}
