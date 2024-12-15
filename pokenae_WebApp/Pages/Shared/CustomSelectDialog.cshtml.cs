using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace pokenae_WebApp.Pages
{
    public class CustomSelectDialogModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ButtonText { get; set; }
        public List<string> Items { get; set; }
        public string SelectedValue { get; set; }

        public bool IsDialogOpen { get; set; }

        public void OpenDialog()
        {
            IsDialogOpen = true;
        }

        public void SelectItem(string item)
        {
            SelectedValue = item;
            IsDialogOpen = false;
        }
    }
}
