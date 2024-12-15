using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace pokenae_WebApp.Pages
{
    public class CustomButtonPostModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ButtonText { get; set; }
        public string? Url { get; set; }
    }
}
