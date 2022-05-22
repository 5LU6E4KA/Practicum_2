using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Practicum_2
{
    internal class ExceptionFunctions
    {
        public static Exception Ex_Int(string input_str, string data, int min = -2147483648, int max = 2147483647)
        {
            try
            {
                int result = Convert.ToInt32(input_str);
                if (result < min)
                {
                    throw new Exception($"Число меньше разрешенного");
                }
                if (result > max)
                {
                    throw new Exception($"Число больше разрешенного");
                }
            }
            catch (Exception ex)
            {
                return ex;
            }
            return null;
        }
    }
    internal class MatrixRasschet
    {
        public static List<int> Main_Diagonal(int[][] matrix)
        {
            int min = matrix[0][0];
            int max = matrix[0][0];
            int amount = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i][i] < min)
                {
                    min = matrix[i][i];
                }
                if (matrix[i][i] > max)
                {
                    max = matrix[i][i];
                }
                amount += matrix[i][i];
            }
            List<int> result = new List<int> { amount, min, max };
            return result;
        }

        public static List<int> Secondary_Diagonal(int[][] matrix)
        {
            int min = matrix[0][0];
            int max = matrix[0][0];
            int amount = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i][matrix.Length - i - 1] < min)
                {
                    min = matrix[i][matrix.Length - i - 1];
                }
                if (matrix[i][matrix.Length - i - 1] > max)
                {
                    max = matrix[i][matrix.Length - i - 1];
                }
                amount += matrix[i][matrix.Length - i - 1];
            }
            List<int> result = new List<int> { amount, min, max };
            return result;
        }

        public static List<int> Top_Triangle(int[][] matrix)
        {
            int min = matrix[0][0];
            int max = matrix[0][0];
            int amount = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = i; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] < min)
                    {
                        min = matrix[i][j];
                    }
                    if (matrix[i][j] > max)
                    {
                        max = matrix[i][j];
                    }
                    amount += matrix[i][j];
                }
            }
            List<int> result = new List<int> { amount, min, max };
            return result;
        }
        public static List<int> Bottom_Triangle(int[][] matrix)
        {
            int min = matrix[0][0];
            int max = matrix[0][0];
            int amount = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    if (matrix[i][j] < min)
                    {
                        min = matrix[i][j];
                    }
                    if (matrix[i][j] > max)
                    {
                        max = matrix[i][j];
                    }
                    amount += matrix[i][j];
                }
            }
            List<int> result = new List<int> { amount, min, max };
            return result;
        }
        public static List<int> Left_Triangle(int[][] matrix)
        {
            int min = matrix[0][0];
            int max = matrix[0][0];
            int amount = 0;

            int average = (int)Math.Ceiling(matrix.Length / 2.0);

            for (int i = 0; i < average; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    if (matrix[i][j] < min)
                    {
                        min = matrix[i][j];
                    }
                    if (matrix[i][j] > max)
                    {
                        max = matrix[i][j];
                    }
                    amount += matrix[i][j];
                }
            }
            for (int i = average; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix.Length - i; j++)
                {
                    if (matrix[i][j] < min)
                    {
                        min = matrix[i][j];
                    }
                    if (matrix[i][j] > max)
                    {
                        max = matrix[i][j];
                    }
                    amount += matrix[i][j];
                }
            }
            List<int> result = new List<int> { amount, min, max };
            return result;
        }
        public static List<int> Right_Triangle(int[][] matrix)
        {
            int min = matrix[0][0];
            int max = matrix[0][0];
            int amount = 0;

            int average = (int)Math.Ceiling(matrix.Length / 2.0);

            for (int i = 0; i < average; i++)
            {
                for (int j = matrix.Length - i - 1; j < matrix.Length; j++)
                {
                    if (matrix[i][j] < min)
                    {
                        min = matrix[i][j];
                    }
                    if (matrix[i][j] > max)
                    {
                        max = matrix[i][j];
                    }
                    amount += matrix[i][j];
                }
            }
            for (int i = average; i < matrix.Length; i++)
            {
                for (int j = i; j < matrix.Length; j++)
                {
                    if (matrix[i][j] < min)
                    {
                        min = matrix[i][j];
                    }
                    if (matrix[i][j] > max)
                    {
                        max = matrix[i][j];
                    }
                    amount += matrix[i][j];
                }
            }
            List<int> result = new List<int> { amount, min, max };
            return result;
        }
    }

    public partial class MainWindow : Window
    {
        static int[][] matrix = new int[10][];
        public MainWindow()
        {
            InitializeComponent();
            Get_Random_Matrix();
        }
        private void Matrix_Out(int[][] matrix)
        {
            ObservableCollection<string[]> data = new ObservableCollection<string[]> { };
            for (int i = 0; i < matrix.Length; i++)
            {
                string[] rows = new string[matrix[i].Length];
                for (int j = 0; j < rows.Length; j++)
                {
                    rows[j] = Convert.ToString(matrix[i][j]);
                }
                data.Add(rows);
            }
            MainDataGrid.ItemsSource = data;
            All_Out();
        }
        private void Get_Random_Matrix()
        {
            Random rnd = new Random();
            for (int i = 0; i < matrix.Length; i++)
            {
                int[] int_row = new int[matrix.Length];
                int num;
                for (int j = 0; j < int_row.Length; j++)
                {
                    num = rnd.Next(-99, 99);
                    int_row[j] = num;
                }
                matrix[i] = int_row;
            }
            Matrix_Out(matrix);
            All_Out();
        }

        private void GetRandom_Button_Click(object sender, RoutedEventArgs e)
        {
            Get_Random_Matrix();
        }

        private void Set_Values_Click(object sender, RoutedEventArgs e)
        {
            var items = MainDataGrid.ItemsSource;
            int i = 0;
            int j = 0;
            foreach (string[] elem in items)
            {
                string[] row = elem;
                j = 0;
                foreach (var item in row)
                {
                    Exception ex = ExceptionFunctions.Ex_Int(item, "Элемент");
                    if (ex == null)
                    {
                        matrix[i][j] = Convert.ToInt32(item);
                    }
                    else
                    {
                        matrix[i][j] = 0;
                    }
                    j++;
                }
                i++;
            }
            Matrix_Out(matrix);
            All_Out();
        }
        private void All_Out()
        {
            List<int> main_diag = MatrixRasschet.Main_Diagonal(matrix);
            maindiagonal_amount.Text = Convert.ToString(main_diag[0]);
            maindiagonal_min.Text = Convert.ToString(main_diag[1]);
            maindiagonal_max.Text = Convert.ToString(main_diag[2]);
            List<int> second_diag = MatrixRasschet.Secondary_Diagonal(matrix);
            secondarydiagonal_amount.Text = Convert.ToString(second_diag[0]);
            secondarydiagonal_min.Text = Convert.ToString(second_diag[1]);
            secondarydiagonal_max.Text = Convert.ToString(second_diag[2]);
            List<int> top_triang = MatrixRasschet.Top_Triangle(matrix);
            toptriangle_amount.Text = Convert.ToString(top_triang[0]);
            toptriangle_min.Text = Convert.ToString(top_triang[1]);
            toptriangle_max.Text = Convert.ToString(top_triang[2]);
            List<int> bottom_triang = MatrixRasschet.Bottom_Triangle(matrix);
            bottomtriangle_amount.Text = Convert.ToString(bottom_triang[0]);
            bottomtriangle_min.Text = Convert.ToString(bottom_triang[1]);
            bottomtriangle_max.Text = Convert.ToString(bottom_triang[2]);
            List<int> left_triang = MatrixRasschet.Left_Triangle(matrix);
            lefttriangle_amount.Text = Convert.ToString(left_triang[0]);
            lefttriangle_min.Text = Convert.ToString(left_triang[1]);
            lefttriangle_max.Text = Convert.ToString(left_triang[2]);
            List<int> right_triang = MatrixRasschet.Right_Triangle(matrix);
            righttriangle_amount.Text = Convert.ToString(right_triang[0]);
            righttriangle_min.Text = Convert.ToString(right_triang[1]);
            righttriangle_max.Text = Convert.ToString(right_triang[2]);
        }
        private void Out_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows[0].Close();
        }
    }
}
