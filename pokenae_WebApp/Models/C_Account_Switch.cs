using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace pokenae_WebApp.Models
{
    /// <summary>
    /// アカウントコレクションのモデル
    /// </summary>
    public class C_Account_Switch
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
                return "CAS";
            }
        }

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public C_Account_Switch()
        {

        }
        ///// <summary>
        ///// 引数のビューモデルなどから生成
        ///// </summary>
        ///// <param name="vm"></param>
        //public C_Account_Switch(AccountCollectionViewModel vm)
        //{
        //    if (vm != null)
        //    {
        //        this.ID = vm.ID;
        //        this.Name = vm.Name;
        //        this.Memo = vm.Memo;
        //    }
        //}

    }
}
