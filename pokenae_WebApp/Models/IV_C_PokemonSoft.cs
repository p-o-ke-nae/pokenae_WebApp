using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pokenae_WebApp.Models
{
    public interface IV_C_PokemonSoft
    {
        [DisplayName("ID")]
        public string ID { get; set; }
        [DisplayName("ラベル")]
        public string? Label { get; set; }
        [DisplayName("ポケモンソフトコード")]
        public string MPokemonSoftCODE { get; set; }
        [DisplayName("パッケージ版/DL版")]
        public bool DownloadFlg { get; set; }
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
        public string MDeveloperCODE { get; set; }
        [DisplayName("開発元")]
        public string DeveloperName { get; set; }
        public string MHardCategoryCODE { get; set; }
        [DisplayName("ハード")]
        public string HardCategoryName { get; set; }

        /// <summary>
        /// ビューのインスタンスを元にモデルを生成する
        /// </summary>
        /// <param name="model"></param>
        public IC_PokemonSoft ConvertToModel();
        /// <summary>
        /// 引数より取得したモデルクラスに共通項目を上書きする
        /// </summary>
        /// <param name="model"></param>
        public void ConvertToModel(IC_PokemonSoft model);
    }
}
