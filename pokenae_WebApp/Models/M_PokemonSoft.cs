using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pokenae_WebApp.Models
{
    /// <summary>
    /// ポケモンのソフトのモデル
    /// </summary>
    [Table("PokemonSoft")]
    public class M_PokemonSoft
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
        public string DeveloperCODE { get; set; }

        /// <summary>
        /// ハードID
        /// </summary>
        public string HardCategoryCODE { get; set; }

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


        //DBの操作で必要なもの
        /// <summary>
        /// DBのディレクトリ
        /// </summary>
        public static string DirPath
        {
            get
            {
                return /*PNBase.ExePath + */"pokenaeDB\\" + "PokemonSoft\\";
            }
        }
        /// <summary>
        /// IDのタグ
        /// </summary>
        public static string IDTag
        {
            get
            {
                return "P";
            }
        }


        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public M_PokemonSoft()
        {

        }

    }
}
