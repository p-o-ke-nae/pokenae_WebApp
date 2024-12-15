using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace pokenae_WebApp.Pages
{
    public class CustomTextBoxModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Text { get; set; }
        public bool IsRequired { get; set; }
        public bool IsReadOnly { get; set; }
        public int DataValLengthMax { get; set; }
        public int DataValLengthMin { get; set; }
    }
}
