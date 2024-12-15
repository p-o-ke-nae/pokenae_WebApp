using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace pokenae_WebApp.Pages
{
    public class CustomLabelHeaderModel
    {
        public string Id { get; set; }
        public string? LabelText { get; set; }
        public bool IsRequired { get; set; }
        public bool IsReadOnly { get; set; }

        public string BorderColor => IsRequired ? "red" : IsReadOnly ? "gray" : "black";
    }
}
