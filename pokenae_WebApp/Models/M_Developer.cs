using System.ComponentModel.DataAnnotations.Schema;

namespace pokenae_WebApp.Models
{
    /// <summary>
    /// 開発元のモデル
    /// </summary>
    public class M_Developer
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// IDのタグ
        /// </summary>
        public static string IDTag
        {
            get
            {
                return "D";
            }
        }

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public M_Developer()
        {

        }

    }
}
