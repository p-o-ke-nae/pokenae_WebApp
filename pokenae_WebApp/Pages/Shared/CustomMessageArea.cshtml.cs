using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace pokenae_WebApp.Pages
{
    public class CustomMessageAreaModel
    {
        public string Name { get; set; }
        public string[] Messages { get; set; } // ���b�Z�[�W�̔z��ɕύX
        public string MessageType { get; set; }
        public int? DisplayTime { get; set; } // �\�����ԁi�~���b�j
    }
}
