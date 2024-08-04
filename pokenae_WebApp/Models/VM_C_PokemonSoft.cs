using System.ComponentModel;

namespace pokenae_WebApp.Models
{
    public class VM_C_PokemonSoft
    {
        public string ID { get; set; }
        [DisplayName("ラベル")]
        public string Label { get; set; }
        [DisplayName("タイトル")]
        public string Title { get; set; }
        [DisplayName("名前")]
        public string Name { get; set; }
        [DisplayName("発売日")]
        public DateTime ReleaseDate { get; set; }
        [DisplayName("世代")]
        public double Gen { get; set; }
        public string MPokemonSoftCODE { get; set; }
        public string MDeveloperCODE { get; set; }
        [DisplayName("開発元")]
        public string DeveloperName { get; set; }
        public string MHardCategoryCODE { get; set; }
        [DisplayName("ハード")]
        public string HardCategoryName { get; set; }

        public string? PackageFlg { get; set; }

        public static string ID_Package
        {
            get { return "CPP"; }
        }
        
        public VM_C_PokemonSoft() 
        { 
        
        }
        public VM_C_PokemonSoft(IV_C_PokemonSoft ivc)
        {
            ID = ivc.ID;
            Label = ivc.Label;
            Title = ivc.Title;
            Name = ivc.Name;
            ReleaseDate = ivc.ReleaseDate;
            Gen = ivc.Gen;
            MPokemonSoftCODE = ivc.MPokemonSoftCODE;
            MDeveloperCODE = ivc.MDeveloperCODE;
            DeveloperName = ivc.DeveloperName;
            MHardCategoryCODE = ivc.MHardCategoryCODE;
            HardCategoryName = ivc.HardCategoryName;
        }

        /// <summary>
        /// 引数より取得したパッケージのモデルについて，IDが一致していれば共通の値を上書きする
        /// </summary>
        /// <param name="model"></param>
        public void ConvertToPokemonSoftModel(V_C_PokemonSoft model)
        {
            if (model.ID == this.ID)
            {
                model.Label = this.Label;
                model.Title = this.Title;
                model.Name = this.Name;
                model.ReleaseDate = this.ReleaseDate;
                model.Gen = this.Gen;
                model.MPokemonSoftCODE = this.MPokemonSoftCODE;
                model.MDeveloperCODE = this.MDeveloperCODE;
                model.DeveloperName = this.DeveloperName;
                model.MHardCategoryCODE = this.MHardCategoryCODE;
                model.HardCategoryName = this.HardCategoryName;
            }
        }
        ///// <summary>
        ///// 引数より取得したハードのモデルについて，IDが一致していれば共通の値を上書きする
        ///// </summary>
        ///// <param name="model"></param>
        //public void ConvertToPokemonSoftModel(V_C_PokemonSoft_Hard model)
        //{
        //    if (model.ID == this.ID)
        //    {
        //        model.Label = this.Label;
        //        model.Title = this.Title;
        //        model.Name = this.Name;
        //        model.ReleaseDate = this.ReleaseDate;
        //        model.Gen = this.Gen;
        //        model.MPokemonSoftCODE = this.MPokemonSoftCODE;
        //        model.MDeveloperCODE = this.MDeveloperCODE;
        //        model.DeveloperName = this.DeveloperName;
        //        model.MHardCategoryCODE = this.MHardCategoryCODE;
        //        model.HardCategoryName = this.HardCategoryName;
        //    }
        //}
        ///// <summary>
        ///// 引数より取得したアカウントのモデルについて，IDが一致していれば共通の値を上書きする
        ///// </summary>
        ///// <param name="model"></param>
        //public void ConvertToPokemonSoftModel(V_C_PokemonSoft_Account model)
        //{
        //    if (model.ID == this.ID)
        //    {
        //        model.Label = this.Label;
        //        model.Title = this.Title;
        //        model.Name = this.Name;
        //        model.ReleaseDate = this.ReleaseDate;
        //        model.Gen = this.Gen;
        //        model.MPokemonSoftCODE = this.MPokemonSoftCODE;
        //        model.MDeveloperCODE = this.MDeveloperCODE;
        //        model.DeveloperName = this.DeveloperName;
        //        model.MHardCategoryCODE = this.MHardCategoryCODE;
        //        model.HardCategoryName = this.HardCategoryName;
        //    }
        //}
    }
}
