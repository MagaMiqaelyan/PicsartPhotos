using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Windows.Data.Json;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PicsartPhotos
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Photo> Photos = new ObservableCollection<Photo>();

        public MainPage()
        {
            this.InitializeComponent();
            GetContent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {            
            foreach (var photo in Photos)
            {
                var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri(photo.Url));
                using (IRandomAccessStream fileStream = await file.OpenAsync(FileAccessMode.Read))
                {
                    BitmapImage image = new BitmapImage();
                    image.SetSource(fileStream);                   
                }
            }
        }

        public async void GetContent()
        {
            var url = "https://api.picsart.com/photos/search.json?popular=1&tag=origfte&offset=0&limit=15";
            var client = new HttpClient();
            var response = await client.GetAsync(new Uri(url));
            var jsonText = await response.Content.ReadAsStringAsync();           
            var obj = JObject.Parse(jsonText);
            var entities = obj.GetValue("response") as JArray;

            foreach (var entity in entities)
            {
                var photo = new Photo
                {
                    Url = entity.SelectToken("url").ToString()                    
                };
                Photos.Add(photo);
            }
        }
    }
}
