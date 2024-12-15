using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace pokenae_WebApp.Pages
{
    public class IndexModel : PageModel, IValidatableObject
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public void OnPost()
        {

        }

        /// <summary>
        /// 検証処理
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            const string ErrorPrefix = "Invalid";
            if (ViewModel.TextBoxField == "testa")
            {
                yield return new ValidationResult($"{ErrorPrefix} {nameof(ViewModel.TextBoxField)}");
            }
            if (ViewModel.ComboBoxField == "2")
            {
                yield return new ValidationResult($"{ErrorPrefix} {nameof(ViewModel.ComboBoxField)}");
            }

            if (RequiredField == null)
            {
                yield return new ValidationResult($"{ErrorPrefix} {nameof(RequiredField)}");
            }
            if (string.IsNullOrEmpty(MessageField))
            {
                yield return new ValidationResult($"{ErrorPrefix} {nameof(MessageField)}");
            }

            if (ViewModel.Test == "aa")
            {
                yield return new ValidationResult($"{ErrorPrefix} {nameof(ViewModel.Test)}");
            }
        }

        public JsonResult OnPostValidate([FromBody] InputModel item)
        {
            if (item != null)
            {
                this.ViewModel = item;
                var validationResults = new List<ValidationResult>();
                var validationContext = new ValidationContext(this);
                if (!Validator.TryValidateObject(this, validationContext, validationResults, true))
                {
                    return new JsonResult(new { errors = validationResults.Select(vr => vr.ErrorMessage).ToList() });
                }
            }
            else
            {
                return new JsonResult(new { errors = new List<string>() { "item is null" } });
            }
            
            return new JsonResult(new { errors = new List<string>() });
        }

        public class Test
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }

        public JsonResult OnPostTest([FromBody] InputModel item)
        {
            if (item.CheckBoxField == true)
            {
                return new JsonResult(new { displaytime = 2000, messagetype = "Warning", messages = new List<string>() { "チェックされています" } });
            }
            else
            {
                return new JsonResult(new { messages = new List<string>() { "チェックされていないです" } });
            }

            return new JsonResult(new { messages = new List<string>() { item.TextBoxField } });
        }

        public JsonResult OnPostTest2([FromBody] InputModel item)
        {
            if (item.CheckBoxTest == true)
            {
                return new JsonResult(new { messagetype = "Success", messages = new List<string>() { "チェックされています" } });
            }
            else
            {
                return new JsonResult(new { messages = new List<string>() { "チェックされていないです", item.RadioButtonField } });
            }

            return new JsonResult(new { messages = new List<string>() { item.TextBoxField } });
        }

        public InputModel ViewModel { get; set; } = new InputModel();

        [Required]
        public string RequiredField { get; set; } = "RequiredField";

        [ReadOnly(true)]
        public string ReadOnlyField { get; set; } = "ReadOnlyField";

        public string NormalField { get; set; } = "NormalField";
        public string ButtonField2 { get; set; } = "ButtonField";
        public string ButtonField { get; set; } = "ButtonField2";
        public string MessageField { get; set; } = "MessageField";

        public class InputModel
        {

            public bool CheckBoxField { get; set; }
            [Required]
            public bool CheckBoxTest { get; set; }

            public string RadioButtonField { get; set; }
            
            [StringLength(5)]
            public string TextBoxField { get; set; }
            public string Test { get; set; }
            [ReadOnly(true)]
            public string ReadOnlyTest { get; set; }
            [Required]
            [Range(1, 10)]
            public double TestValue { get; set; }

            public string ComboBoxField { get; set; }

            public string SelectDialogField { get; set; }

            public InputModel()
            {
                RadioButtonField = "syoki";
                TextBoxField = "value";
                ComboBoxField = string.Empty;
                SelectDialogField = string.Empty;
            }
        }
    }
}
