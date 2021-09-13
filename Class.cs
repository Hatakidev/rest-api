using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BackEnd
{

    public class RetrieveDataClass
    {
        public RetrieveDataClass()
        {
            AddBlog();
        }
        public class BlogViews
        {
            public string id { get; set; }
            public string DisplayTopic { get; set; }
            public string DisplayMain { get; set; }
            public ImageSource BlogImageSource { get; set; }
        }

        public List<BlogViews> BlogList1 = new List<BlogViews>();
        public async Task<List<BlogViews>> GetBlogs()
        {
            RestClient<BlogViews> restClient = new RestClient<BlogViews>();
            var BlogV = await restClient.GetAsync();
            return BlogV;
        }

        public async void AddBlog()
        {
            BlogList1 = await GetBlogs();
            BlogListView.ItemsSource = BlogList1;
        }





    }
}