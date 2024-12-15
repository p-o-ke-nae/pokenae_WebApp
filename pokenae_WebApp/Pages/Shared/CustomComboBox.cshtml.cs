using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace pokenae_WebApp.Pages
{
    public class CustomComboBoxModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<SelectListItem> Items { get; set; }
        public string SelectedValue { get; set; }
    }
}
