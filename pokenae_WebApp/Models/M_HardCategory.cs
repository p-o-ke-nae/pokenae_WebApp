namespace pokenae_WebApp.Models
{
    /// <summary>
    /// ゲーム機のカテゴリ
    /// </summary>
    public class M_HardCategory
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get; set; }


        //DBの操作で必要なもの
        /// <summary>
        /// DBのディレクトリ
        /// </summary>
        public static string DirPath
        {
            get
            {
                return /*PNBase.ExePath +*/ "pokenaeDB\\" + "HardCategory\\";
            }
        }
        /// <summary>
        /// IDのタグ
        /// </summary>
        public static string IDTag
        {
            get
            {
                return "HC";
            }
        }


        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public M_HardCategory()
        {

        }

    }
}
