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
	public partial class DivisionCriteriaPage : ContentPage
	{
		public DivisionCriteriaPage ()
		{
			InitializeComponent ();
		}

        public bool goodData(ulong n, ulong p)
        {
            if ((p == 0) && (n == 0))
            {
                DisplayAlert("...", "Мммм... Вы знаете толк в извращениях :)", "Ой!");
                return false;
            }

            if (n == 0)
            {
                DisplayAlert("Секундочку...", "Зачем Вы пытаетесь определить признак делимости нуля?", "Ой!");
                return false;
            }

            if (p == 0)
            {
                DisplayAlert("Секундочку...", "Зачем Вы пытаетесь определить признак делимости на 0?", "Ой!");
                return false;
            }
            return true;
        }

        private static bool isNumber(string s)
        {
            bool b = long.TryParse(s, out long i);
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

        private void Ar1Clicked(object sender, EventArgs e)
        {
            if (badData(TextBox1.Text, TextBox2.Text)) return;

            long n = Convert.ToInt64(TextBox1.Text);
            long p = Convert.ToInt64(TextBox2.Text);
            string log = string.Empty;

            if (!goodData((ulong)n, (ulong)p)) return;

            Arachinskiy.Ar1(n, p, ref log);

            this.Solution.Text = log;
        }

        private void Ar2Clicked(object sender, EventArgs e)
        {
            if (badData(TextBox1.Text, TextBox2.Text)) return;

            long n = Convert.ToInt64(TextBox1.Text);
            long p = Convert.ToInt64(TextBox2.Text);
            string log = string.Empty;

            if (!goodData((ulong)n, (ulong)p)) return;

            long ks = p % 10;
            if ((ks == 1) || (ks == 9)) ks = 10 - ks;

            long q = ((p * ks) + 1) / 10;

            string log0 = string.Empty;
            if ((ks == 3) || (ks == 7)) log0 = "k=" + p%10 + " => ks=k=" + ks;
            if ((ks == 9) || (ks == 1)) log0 = "k=" + p%10 + " => ks=10-k=" + ks;
            log0 += "\n";
            string log1 = "q=(" + p + "*" + ks + "+1)/10=" + q + ";\n";

            Arachinskiy.Ar2(n, p, q, ref log);

            Solution.Text = log0 + log1 + log;
        }

        private void Ar3Clicked(object sender, EventArgs e)
        {
            if (badData(TextBox1.Text, TextBox2.Text)) return;
            long n = Convert.ToInt64(TextBox1.Text);
            long p = Convert.ToInt64(TextBox2.Text);

            if (!goodData((ulong)n, (ulong)p)) return;

            string log = string.Empty;

            long ks = p % 10;
            if ((ks == 1) || (ks == 9)) ks = 10 - ks;

            long q = ((p * ks) + 1) / 10;
            long qs = Math.Abs(p - q);

            string log0 = string.Empty;
            if ((ks == 3) || (ks == 7)) log0 = "k=" + p % 10 + " => ks=k=" + ks;
            if ((ks == 9) || (ks == 1)) log0 = "k=" + p % 10 + " => ks=10-k=" + ks;
            log0 += "\n";
            string log1 = "q=(" + p + "*" + ks + "+1)/10=" + q + ";\n";
            string log2 = "qs=|" + p + "-" + q + "|=" + qs + "\n";

            Arachinskiy.Ar3(n, p, qs, ref log);

            Solution.Text = log0 + log1 + log2 + log;
        }

        private void PascalClicked(object sender, EventArgs e)
        {
            if (badData(TextBox1.Text, TextBox2.Text)) return;

            ulong n = (ulong)Convert.ToInt64(TextBox1.Text);
            ulong p = (ulong)Convert.ToInt64(TextBox2.Text);
            string log = string.Empty;

            if (!goodData(n, p)) return;

            Pascal pascal = new Pascal(n, p, ref log);
            pascal.PascalDiv(n, p, ref log);

            Solution.Text = log;
        }

        private void UnnamedClicked(object sender, EventArgs e)
        {
            if (badData(TextBox1.Text, TextBox2.Text)) return;

            ulong n = (ulong)Convert.ToInt64(TextBox1.Text);
            ulong p = (ulong)Convert.ToInt64(TextBox2.Text);
            string log = string.Empty;

            if (!goodData(n, p)) return;

            Unnamed unnamed = new Unnamed(n, p, ref log);
            unnamed.UnnamedDiv(n, p, ref log);

            Solution.Text = log;
        }
    }
}