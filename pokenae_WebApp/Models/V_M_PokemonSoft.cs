using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pokenae_WebApp.Models
{
    /// <summary>
    /// ポケモンのソフトのビュー
    /// </summary>
    public class V_M_PokemonSoft
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        [Required]
        public string ID { get; set; }

        /// <summary>
        /// タイトル
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 発売日
        /// </summary>
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// 開発元ID
        /// </summary>
        public string MDeveloperCODE { get; set; }

        /// <summary>
        /// 開発元名称
        /// </summary>
        public string DeveloperName { get; set; }

        /// <summary>
        /// ハードID
        /// </summary>
        public string MHardCategoryCODE { get; set; }

        /// <summary>
        /// ハード名称
        /// </summary>
        public string HardCategoryName { get; set; }

        /// <summary>
        /// 世代
        /// </summary>
        public double Gen { get; set; }

        /// <summary>
        /// パッケージ版が存在するフラグ
        /// </summary>
        public bool PackageFlg { get; set; }

        /// <summary>
        /// DL版が存在するフラグ
        /// </summary>
        public bool DLFlg { get; set; }

    }
}
