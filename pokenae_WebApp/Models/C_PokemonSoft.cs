namespace pokenae_WebApp.Models
{
    /// <summary>
    /// パッケージ版ソフトのモデル
    /// </summary>
    public class C_PokemonSoft:IC_PokemonSoft
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// ラベル
        /// </summary>
        public string? Label { get; set; }

        /// <summary>
        /// ポケモンソフトのID
        /// </summary>
        public string MPokemonSoftCODE { get; set; }

        /// <summary>
        /// パッケージ版/DL版を管理するフラグ
        /// </summary>
        public bool DLFlg { get; set; }

        /// <summary>
        /// メモ
        /// </summary>
        public string? Memo { get; set; }

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public C_PokemonSoft()
        {

        }

    }
}
