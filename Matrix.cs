using System;
using System.Text;

namespace Lab3
{
    public class Matrix
    {
        private double[,] _data;

        public int Rows
        {
            get { return _data.GetLength(0); }
        }

        public int Cols
        {
            get { return _data.GetLength(1); }
        }

        public double this[int i, int j]
        {
            get { return _data[i, j]; }
            set { _data[i, j] = value; }
        }

        public Matrix(int rows, int cols)
        {
            _data = new double[rows, cols];
        }

        public Matrix(Matrix other)
        {
            _data = new double[other.Rows, other.Cols];
            Array.Copy(other._data, _data, other._data.Length);
        }

        public Matrix(double[,] array)
        {
            _data = (double[,])array.Clone();
        }
        
        public Matrix(int rows, int cols, bool fromKeyboard)
        {
            _data = new double[rows, cols];
            if (!fromKeyboard)
            {
                return;
            }

            Console.WriteLine("Заполнение матрицы по диагоналям (параллельно побочной, с правого нижнего угла):");
            int maxSum = (rows - 1) + (cols - 1);
            
            for (int s = maxSum; s >= 0; s--)
            {
                for (int i = rows - 1; i >= 0; i--)
                {
                    int j = s - i;
                    if (j >= 0 && j < cols)
                    {
                        Console.Write($"Элемент [{i+1},{j+1}]: ");
                        string input = Console.ReadLine();
                        double val;
                        while (!double.TryParse(input, out val))
                        {
                            Console.Write("Ошибка, Введите число: ");
                            input = Console.ReadLine();
                        }
                        _data[i, j] = val;
                    }
                }
            }
        }
        
        public Matrix(int n, Random rnd)
        {
            _data = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j > i)
                    {
                        _data[i, j] = Math.Round(0.501 + rnd.NextDouble() * 0.499, 3);
                    }
                    else
                    {
                        _data[i, j] = Math.Round(rnd.NextDouble() * 0.5, 3);
                    }
                }
            }
        }
        
        public Matrix(int n)
        {
            _data = new double[n, n];
            int val = n*n;
            int top = 0;
            int bottom = n - 1;
            int left = 0;
            int right = n - 1;

            while (top <= bottom && left <= right)
            {
                for (int i = top; i <= bottom; i++)
                {
                    _data[i, left] = val;
                    val--;
                }
                left++;
                
                if (top <= bottom)
                {
                    for (int j = left; j <= right; j++)
                    {
                        _data[bottom, j] = val;
                        val--;
                    }
                    bottom--;
                }
                
                if (left <= right)
                {
                    for (int i = bottom; i >= top; i--)
                    {
                        _data[i, right] = val;
                        val--;
                    }
                    right--;
                }
                
                if (top <= bottom)
                {
                    for (int j = right; j >= left; j--)
                    {
                        _data[top, j] = val;
                        val--;
                    }
                    top++;
                }
            }
        }
        
        public void Task2_MultiplyColumns()
        {
            if (Rows != Cols)
            {
                Console.WriteLine("Матрица должна быть квадратной");
                return;
            }

            int n = Rows;
            double maxDiag = _data[0, 0];
            
            for (int i = 0; i < n; i++)
            {
                if (_data[i, i] > maxDiag)
                {
                    maxDiag = _data[i, i];
                }
                if (_data[i, n - 1 - i] > maxDiag)
                {
                    maxDiag = _data[i, n - 1 - i];
                }
            }

            Console.WriteLine($"Максимум на диагоналях: {maxDiag}");

            bool found = false;
            for (int j = 0; j < Cols; j++)
            {
                if (_data[0, j] > maxDiag)
                {
                    found = true;
                    double product = 1.0;
                    for (int i = 0; i < Rows; i++)
                    {
                        product *= _data[i, j];
                    }
                    Console.WriteLine($"Столбец {j}: Произведение = {product}");
                }
            }

            if (!found)
            {
                Console.WriteLine("Таких столбцов нет.");
            }
        }

        public Matrix Transpose()
        {
            Matrix result = new Matrix(Cols, Rows);
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    result[j, i] = _data[i, j];
                }
            }
            return result;
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            Matrix res = new Matrix(a.Rows, a.Cols);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Cols; j++)
                {
                    res[i, j] = a[i, j] + b[i, j];
                }
            }
            return res;
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            Matrix res = new Matrix(a.Rows, a.Cols);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Cols; j++)
                {
                    res[i, j] = a[i, j] - b[i, j];
                }
            }
            return res;
        }

        public static Matrix operator *(double scalar, Matrix a)
        {
            Matrix res = new Matrix(a.Rows, a.Cols);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Cols; j++)
                {
                    res[i, j] = a[i, j] * scalar;
                }
            }
            return res;
        }

        public static Matrix operator *(Matrix a, double scalar)
        {
            return scalar * a;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    sb.Append(Math.Round(_data[i, j], 3) + "\t");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}