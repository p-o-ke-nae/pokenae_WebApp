using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace pokenae_WebApp.Models
{
    /// <summary>
    /// PokemonReportCollectionViewModelの共通事項
    /// </summary>
    public interface IPokemonReportCollectionViewModel
    {
        /// <summary>
        /// ID
        /// </summary>
        [Display(Name = "ID")]
        public string ID { get; set; }

        /// <summary>
        /// タイトル
        /// </summary>
        [Display(Name = "タイトル")]
        public string Title { get; set; }

        /// <summary>
        /// ラベル
        /// </summary>
        [Display(Name = "ラベル")]
        public string Label { get; set; }

        /// <summary>
        /// レポートのある場所
        /// ソフトの種類によって，ソフトだったりハードだったりハードのアカウントだったりする
        /// </summary>
        [Display(Name = "保存場所")]
        public string ReportPlace { get; }

        /// <summary>
        /// 主人公の名前
        /// </summary>
        [Display(Name = "TN")]
        public string TN { get; set; }

        /// <summary>
        /// 主人公のID
        /// 表ID
        /// </summary>
        [Display(Name = "TID")]
        public long TID { get; set; }

        /// <summary>
        /// 裏ID
        /// </summary>
        [Display(Name = "SID")]
        public long SID { get; set; }

        /// <summary>
        /// 主人公の性別
        /// </summary>
        [Display(Name = "性別")]
        public string Gender { get; set; }

        /// <summary>
        /// 進捗
        /// </summary>
        [Display(Name = "ストーリー進捗")]
        public string Progress { get; set; }

        /// <summary>
        /// メモ
        /// </summary>
        [Display(Name = "メモ")]
        public string Memo { get; set; }

    }
}
