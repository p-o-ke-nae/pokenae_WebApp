using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace pokenae_WebApp.Pages
{
    public class CustomTextBoxModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Rows { get; set; }
        public string Text { get; set; }
    }
}
