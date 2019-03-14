using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ControlWork1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MultiplicationPage : ContentPage
	{
		public MultiplicationPage ()
		{
			InitializeComponent ();
		}

        private static bool isNumber(string s)
        {
            bool b = int.TryParse(s, out int i);
            return b;
        }

        private static bool isNumber(string str1, string str2)
        {
            bool b = ((isNumber(str1)) && (isNumber(str2)));
            return b;
        }

        private static bool checkEmpty(string str1, string str2)
        {
            bool b = ((str1 == null) || (str2 == null));
            return b;
        }

        public bool badData(string str1, string str2)
        {
            bool b1 = checkEmpty(str1, str2);
            bool b2 = isNumber(str1, str2);
            bool b = (b1 ? true : !b2);
            if (b) DisplayAlert("Warning!", "Заполните пустые строки и проверьте корректность введённых чисел!", "Сейчас проверю!");
            return b;
        }

        public bool goodData(string n, string p)
        {
            if ((p == "0") && (n == "0"))
            {
                DisplayAlert("...", "Зачем Вы пытаетесь перемножить два нуля друг на друга?", "Ой!");
                return false;
            }

            if ((p == "0") || (n == "0"))
            {
                DisplayAlert("Секундочку...", "Зачем Вы пытаетесь определить умножить на 0?", "Ой!");
                return false;
            }
            return true;
        }

        private void FourieClicked(object sender, EventArgs e)
        {
            if (badData(TextBox1.Text, TextBox2.Text)) return;
            string x = TextBox1.Text;
            string y = TextBox2.Text;
            string log = string.Empty;

            if (!goodData(x, y)) return;

            string res = Fourie.FourieMultiplication(x, y, ref log);

            Result.Text = res;
            Solution.Text = log;
        }

        private void ShortClicked(object sender, EventArgs e)
        {
            if (badData(TextBox1.Text, TextBox2.Text)) return;
            string x = TextBox1.Text;
            string y = TextBox2.Text;
            string log = string.Empty;

            if (!goodData(x, y)) return;

            string res = Shortened.ShortMultiplication(x, y, ref log);

            Result.Text = res;
            Solution.Text = log;
        }
    

        private void RussianClicked(object sender, EventArgs e)
        {
            if (badData(TextBox1.Text, TextBox2.Text)) return;
            ulong x = (ulong)Convert.ToInt64(TextBox1.Text);
            ulong y = (ulong)Convert.ToInt64(TextBox2.Text);
            string log = string.Empty;

            if (!goodData(x.ToString(), y.ToString())) return;

            string res = Russian.RussianMultiplication(x, y, ref log);

            Result.Text = res;
            Solution.Text = log;
        }

        private void KarazubaClicked(object sender, EventArgs e)
        {
            if (badData(TextBox1.Text, TextBox2.Text)) return;
            ulong x = (ulong)Convert.ToInt64(TextBox1.Text);
            ulong y = (ulong)Convert.ToInt64(TextBox2.Text);
            string log = string.Empty;

            if (!goodData(x.ToString(), y.ToString())) return;

            string res = Karazuba.KarazubaMultiplication(x, y, ref log, 0).ToString();

            Result.Text = res;
            Solution.Text = log;
        }

    }
}