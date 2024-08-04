namespace pokenae_WebApp.Models
{
    /// <summary>
    /// Switchのハードコレクションのモデル
    /// </summary>
    public class C_Hard_Switch
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// ラベル
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// ハードのID
        /// </summary>
        public string HardCODE { get; set; }

        /// <summary>
        /// バージョンなど保持しているもの
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// メモ
        /// </summary>
        public string Memo { get; set; }


        /// <summary>
        /// IDのタグ
        /// </summary>
        public static string IDTag
        {
            get
            {
                return "CHS";
            }
        }

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public C_Hard_Switch()
        {

        }
        
        //public C_Hard_Switch(HardCollectionViewModel vm)
        //{
        //    if (vm != null)
        //    {
        //        this.ID = vm.ID;
        //        this.Label = vm.Label;
        //        this.HardCODE = vm.Hard_ID;
        //        this.Version = vm.Keep;
        //        this.Memo = vm.Memo;
        //    }
        //}

    }
}
