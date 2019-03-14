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
    public partial class MatrixPage : ContentPage
    {
        private Entry[][] matrix1;
        private Entry[][] matrix2;
        

        public MatrixPage()
        {
            InitializeComponent();
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

        private static long matrixSize(int s)
        {
            int x = 1;
            for (int i = 0; i < s; i++)
                x <<= 1;
            return x;
        }

        public void StepperValChanged(object sender, EventArgs e)
        {
            NumberLabel.Text = NumberStepper.Value.ToString();
            long side = matrixSize((int)NumberStepper.Value);

            Entry[][][] matrix = new Entry[2][][];
            matrix[0] = matrix1;
            matrix[1] = matrix2;

            Grid[] MatrixField = new Grid[2];
            MatrixField[0] = MatrixField1;
            MatrixField[1] = MatrixField2;

            for (int nom = 0; nom < 2; nom++)
            {
                MatrixField[nom].Children.Clear();
                MatrixField[nom].RowDefinitions.Clear();
                MatrixField[nom].ColumnDefinitions.Clear();

                matrix[nom] = new Entry[side][];

                for (int i = 0; i < side; i++)
                {
                    RowDefinition row = new RowDefinition();
                    MatrixField[nom].RowDefinitions.Add(row);
                }

                for (int i = 0; i < side; i++)
                {
                    ColumnDefinition col = new ColumnDefinition();
                    MatrixField[nom].ColumnDefinitions.Add(col);
                }

                for (int i = 0; i < side; i++)
                {
                    matrix[nom][i] = new Entry[side];
                    for (int j = 0; j < side; j++)
                    {
                        matrix[nom][i][j] = new Entry();
                        matrix[nom][i][j].Keyboard = Xamarin.Forms.Keyboard.Numeric;
                        Grid.SetColumn(matrix[nom][i][j], i);
                        Grid.SetRow(matrix[nom][i][j], j);
                        MatrixField[nom].Children.Add(matrix[nom][i][j]);
                    }
                }
            }
            matrix1 = matrix[0];
            matrix2 = matrix[1];
        }

        public void StrassenClicked(object sender, EventArgs e)
        {
            string log = string.Empty;
            int n = (int)matrixSize((int)NumberStepper.Value);
            int[][] matr1 = new int[n][];
            int[][] matr2 = new int[n][];

            for (int j = 0; j < n; j++)
            {
                matr1[j] = new int[n];
                matr2[j] = new int[n];
                for (int i = 0; i < n; i++)
                {
                    if (badData(matrix1[j][i].Text, matrix2[j][i].Text)) return;

                    matr1[j][i] = Convert.ToInt32(matrix1[i][j].Text);
                    matr2[j][i] = Convert.ToInt32(matrix2[i][j].Text);
                }
            }

            int[][] res = Strassen.MUL(matr1, matr2, n, ref log, 0);
            Result.Text = Strassen.outputMatrix(res,n,0);
            Solution.Text = log;
        }
    }
}