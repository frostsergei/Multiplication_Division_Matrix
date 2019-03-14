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
	public partial class Determinant : ContentPage
	{
		public Determinant ()
		{
			InitializeComponent ();
		}

        private Entry[][] matrix;

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

        public void StepperValChanged(object sender, EventArgs e)
        {
            NumberLabel.Text = NumberStepper.Value.ToString();

            MatrixField.Children.Clear();
            MatrixField.RowDefinitions.Clear();
            MatrixField.ColumnDefinitions.Clear();

            matrix = new Entry[(int)NumberStepper.Value][];

            for (int i = 0; i < NumberStepper.Value; i++)
            {
                RowDefinition row = new RowDefinition();
                MatrixField.RowDefinitions.Add(row);
            }

            for (int i = 0; i < NumberStepper.Value; i++)
            {
                ColumnDefinition col = new ColumnDefinition();
                MatrixField.ColumnDefinitions.Add(col);
            }

            for (int i = 0; i < NumberStepper.Value; i++)
            {
                matrix[i] = new Entry[(int)NumberStepper.Value];
                for (int j = 0; j < NumberStepper.Value; j++)
                {
                    matrix[i][j] = new Entry();
                    matrix[i][j].Keyboard = Xamarin.Forms.Keyboard.Numeric;
                    Grid.SetColumn(matrix[i][j],i);
                    Grid.SetRow(matrix[i][j], j);
                    MatrixField.Children.Add(matrix[i][j]);
                }
            }
        }

        public void DeterminantClicked(object sender, EventArgs e)
        {
            string log = string.Empty;
            int n = (int)NumberStepper.Value;
            int[][] matr = new int[n][];

            for (int i = 0; i < n; i++)
            {
                matr[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    if (badData(matrix[i][j].Text, matrix[i][j].Text)) return;

                    matr[i][j] = Convert.ToInt32(matrix[i][j].Text);
                }
            }
            int[][] det = ProcessMatrix.stepMatrix(matr, ProcessMatrix.createMatrixOnes(n - 1), n, ref log);
            Solution.Text = log;

            if (det == null)
            {
                DisplayAlert("Ошибка",
                    "Во введённой матрице не соответствуют условия возможности нахождения определителя. Поправьте исходную матрицу. Если она верна, то поменяйте местами строки или столбцы. Вдруг поможет:)",
                    "Сейчас исправлю!");
                return;
            }
            Result.Text = det[0][0].ToString();
            

        }
	}
}