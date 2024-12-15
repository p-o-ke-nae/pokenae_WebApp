using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace pokenae_WebApp.Pages
{
    public class CustomRadioButtonModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<RadioButtonOption> Options { get; set; }
        public string SelectedOption { get; set; }
    }

    public class RadioButtonOption
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
}
