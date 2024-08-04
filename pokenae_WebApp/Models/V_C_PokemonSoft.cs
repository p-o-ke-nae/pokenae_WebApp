using System.ComponentModel;

namespace pokenae_WebApp.Models
{
    public class V_C_PokemonSoft : IV_C_PokemonSoft
    {
        public static string IDStr = "CPS";


        [DisplayName("ID")]
        public string ID { get; set; }
        [DisplayName("ラベル")]
        public string? Label { get; set; }
        [DisplayName("ポケモンソフトコード")]
        public string MPokemonSoftCODE { get; set; }
        [DisplayName("パッケージ版/DL版")]
        public bool DLFlg { get; set; }
        [DisplayName("メモ")]
        public string? Memo { get; set; }
       
        [DisplayName("タイトル")]
        public string Title { get; set; }
        [DisplayName("名前")]
        public string Name { get; set; }
        [DisplayName("発売日")]
        public DateTime ReleaseDate { get; set; }
        [DisplayName("世代")]
        public double Gen { get; set; }
        [DisplayName("開発元コード")]
        public string MDeveloperCODE { get; set; }
        [DisplayName("開発元")]
        public string DeveloperName { get; set; }
        [DisplayName("ハードコード")]
        public string MHardCategoryCODE { get; set; }
        [DisplayName("ハード")]
        public string HardCategoryName { get; set; }

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public V_C_PokemonSoft()
        {

        }

        public IC_PokemonSoft ConvertToModel()
        {
            var model = new C_PokemonSoft();
            model.ID = this.ID;
            ConvertToModel(model);

            return model;
        }
        public void ConvertToModel(IC_PokemonSoft model)
        {
            if (model.ID == this.ID)
            {
                model.Label = this.Label;
                model.MPokemonSoftCODE = this.MPokemonSoftCODE;
                model.DLFlg = this.DLFlg;
                model.Memo = this.Memo;
            }
        }
    }
}
