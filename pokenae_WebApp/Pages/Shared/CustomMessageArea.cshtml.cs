using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace pokenae_WebApp.Pages
{
    public class CustomMessageAreaModel
    {
        public string Name { get; set; }
        public string[] Messages { get; set; } // メッセージの配列に変更
        public string MessageType { get; set; }
        public int? DisplayTime { get; set; } // 表示時間（ミリ秒）
    }
}
