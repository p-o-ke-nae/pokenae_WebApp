using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace pokenae_WebApp.Pages
{
    public class CustomCheckBoxModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public bool IsChecked { get; set; }
    }
}
