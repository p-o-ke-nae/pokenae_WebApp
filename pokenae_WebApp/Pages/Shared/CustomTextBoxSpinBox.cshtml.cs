using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Numerics;

namespace pokenae_WebApp.Pages
{
    public class CustomTextBoxSpinBoxModel
    {
        private string _value;

        public string Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 数値しか入らないよう調整する
        /// </summary>
        public string Value
        {
            get
            {
                double result = 0;
                if(!double.TryParse(_value, out result))
                {
                    result = 0;
                }

                if(MinValue != null && MinValue > result)
                {
                    result = (double)MinValue;
                }
                else if (MinValue != null && MaxValue < result)
                {
                    result = (double)MaxValue;
                }

                _value = result.ToString();
                return _value;
            }
            set
            {
                _value = value;
            }
        }
        public bool IsRequired { get; set; }
        public bool IsReadOnly { get; set; }
        public double? MaxValue { get; set; }
        public double? MinValue { get; set; }
        /// <summary>
        /// デフォルトのインクリメント値を1に設定
        /// </summary>
        public double Step { get; set; } = 1;
        /// <summary>
        /// デフォルトの小数点表示数を2に設定
        /// </summary>
        public int DecimalPlaces { get; set; } = 2;
    }
}
