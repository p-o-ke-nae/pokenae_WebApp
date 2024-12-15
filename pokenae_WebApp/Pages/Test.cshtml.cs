using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace pokenae_WebApp.Pages
{
    public class TestModel : PageModel, IValidatableObject
    {
        public InputModel ViewModel { get; set; }

        public string? ButtonShowName { get; set; }
        public string? ButtonLvUp { get; set; }

        #region ページの入力項目
        public class InputModel
        {
            [Required]
            [StringLength(6)]
            public string PokemonName { get; set; }
            [StringLength(6)]
            public string? PokemonNickName { get; set; }
            [ReadOnly(true)]
            public string PokemonTrainer
            {
                get
                {
                    return "oza";
                }
            }
            public string PokemonShowType { get; set; }
            public List<RadioButtonOption> PokemonShowTypeList { get; set; }

            [Range(1,100)]
            public int PokemonLevel { get; set; }

            public bool GetCheck { get; set; }

            public string? Move1 { get; set; }

            public InputModel()
            {
                PokemonName = "ナエトル";
                PokemonLevel = 5;
                PokemonShowType = "Name";
                PokemonShowTypeList = new List<RadioButtonOption>
                {
                    new RadioButtonOption { Text = "名前", Value = "Name" },
                    new RadioButtonOption { Text = "ニックネーム", Value = "NickName" }
                };
            }
        }

        #endregion

        public TestModel()
        {
            ViewModel = new InputModel();
        }

        public void OnGet()
        {
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

        public IActionResult OnPostShowName([FromBody] InputModel item)
        {
            this.ViewModel = item;
            if (this.ViewModel.PokemonShowType == "NickName")
            {
                return new JsonResult(new { displaytime = 4000, messagetype = "Info", messages = new List<string>() { this.ViewModel.PokemonTrainer + "の" + this.ViewModel.PokemonNickName } });
            }
            else
            {
                return new JsonResult(new { displaytime = 4000, messagetype = "Info", messages = new List<string>() { this.ViewModel.PokemonName } });
            }
        }

        public JsonResult OnPostLvUp([FromBody] InputModel item)
        {
            this.ViewModel = item;
            if (item.PokemonLevel != 5)
            {
                return new JsonResult(new { displaytime = 2000, messagetype = "Success", messages = new List<string>() { "Lv." + this.ViewModel.PokemonLevel + "にレベルアップ！" } });
            }
            else
            {
                return new JsonResult(new { displaytime = 2000, messagetype = "Warning", messages = new List<string>() { "Lv.は変更されていません．" } });
            }
        }


        /// <summary>
        /// 検証処理
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            const string ErrorPrefix = "Invalid";
            if (ViewModel.PokemonLevel != 5 && ViewModel.GetCheck == false && ViewModel.PokemonLevel > 5)
            {
                yield return new ValidationResult($"{ErrorPrefix} {nameof(ViewModel.GetCheck)}");
                yield return new ValidationResult($"{ErrorPrefix} {nameof(ViewModel.PokemonLevel)}");
            }
            if (ViewModel.PokemonLevel < 5)
            {
                yield return new ValidationResult($"{ErrorPrefix} {nameof(ViewModel.PokemonLevel)}");
            }
        }


    }
}
