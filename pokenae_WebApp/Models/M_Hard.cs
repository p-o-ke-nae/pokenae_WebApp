using System.ComponentModel.DataAnnotations.Schema;

namespace pokenae_WebApp.Models
{
    /// <summary>
    /// ゲーム機のモデル
    /// </summary>
    public class M_Hard
    {
        /// <summary>
        /// ID
        /// </summary>
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
        /// ハードのカテゴリID
        /// </summary>
        public string HardCategoryCODE { get; set; }


        //DBの操作で必要なもの
        /// <summary>
        /// DBのディレクトリ
        /// </summary>
        public static string DirPath
        {
            get
            {
                return /*PNBase.ExePath + */"pokenaeDB\\" + "Hard\\";
            }
        }
        /// <summary>
        /// IDのタグ
        /// </summary>
        public static string IDTag
        {
            get
            {
                return "H";
            }
        }


        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public M_Hard()
        {

        }

    }
}
