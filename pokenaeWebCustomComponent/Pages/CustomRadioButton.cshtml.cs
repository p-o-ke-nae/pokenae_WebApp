using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace pokenae_WebApp.Pages
{
    public class CustomRadioButtonModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<string> Options { get; set; }
        public string SelectedOption { get; set; }
    }
}
