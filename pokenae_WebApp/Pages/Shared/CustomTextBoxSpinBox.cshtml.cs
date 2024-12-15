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
        /// ���l��������Ȃ��悤��������
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
        /// �f�t�H���g�̃C���N�������g�l��1�ɐݒ�
        /// </summary>
        public double Step { get; set; } = 1;
        /// <summary>
        /// �f�t�H���g�̏����_�\������2�ɐݒ�
        /// </summary>
        public int DecimalPlaces { get; set; } = 2;
    }
}
