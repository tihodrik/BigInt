using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace polinom
{
    public partial class Form1 : Form
    {
        List<int> m;

        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            R.Clear();
            List<int> result = Result();
            result.Reverse();
            foreach (var digit in result)
                R.AppendText(digit.ToString());
        }
        
        // Вычисление значения многочлена в точке
        private List<int> Result()
        {
            m = new List<int>();
            string str = GetText(this.Controls["Mod"] as TextBox).First();
            for (int i = 0; i < str.Length; i++)
            {
                m.Add((int)(str[i] - 48));
            }
            m.Reverse();

            List<List<int>>a = GetList(GetText(this.Controls["K"] as TextBox));
            List<int> b = GetList(GetText(this.Controls["B"] as TextBox)).First();
            List<List<int>> p = new List<List<int>>();

            int n = a.Count;

            // Ввод коэффициентов должен начинаться со старшей степени: an,..., a0
            // Все исходные значения уже взяты по модулю
            p.Add(a[0]);

            for (int i = 1; i < n; i++)
            {
                p.Add(Module(Sum(karatsuba_mul(p[i - 1], b), a[i])));
            }
                      
            List<int> result = p.Last();
            result = Module(result);

            return result;
        }

        // Сумма больших чисел
        private List<int> Sum(List<int> A, List<int> B)
        {
            int count = A.Count;
            if (B.Count > count)
            {
                count = B.Count;
                AddNulls(ref A, count);
            }
            else
            {
                if (B.Count < count)
                {
                    AddNulls(ref B, count);
                }
            }

            List<int> result = new List<int>(count);
            bool f = false;

            for (int i = 0; i < count; i++)
            {
                if (f)
                {
                    result.Add((A[i] + B[i] + 1) % 10);
                    f = false;
                   
                    if ((A[i] + B[i] + 1) / 10 > 0)
                    {
                        f = true;
                    }
                }
                else
                {
                    result.Add((A[i] + B[i]) % 10);
                    if ((A[i] + B[i]) / 10 > 0)
                    {
                        f = true;
                    }
                }
            }
            if (f)
            {
                result.Add(1);
            }

            return result;
        }
        // Разность больших чисел
        private List<int> Dif(List<int> A, List<int> B)
        {
            // A > B
            int count = A.Count;
            if (B.Count > count)
            {
                count = B.Count;
                AddNulls(ref A, count);
            }
            else
            {
                if (B.Count < count)
                {
                    AddNulls(ref B, count);
                }
            }

            List<int> result = new List<int>(count);

            for (int i = 0; i < count; i++)
            {
                if (A[i] < B[i])
                {
                    A[i + 1]--;
                    result.Add(A[i] + 10 - B[i]);
                }
                else
                {
                    result.Add(A[i] - B[i]);
                }
            }
            return result;
        }
        // Добавление незначащих нулей
        private void AddNulls(ref List<int> item, int count)
        {
            // Все листы реверсированы, значит, самый старший разряд
            // имеет самый большой номер в массиве
            int c = item.Count;
            while (c < count)
            {
                item.Add(0);
                c++;
            }
        }
        // Удаление незначащих нулей
        private void RemoveNulls(ref List<int> item)
        {
            // Все листы реверсированы, значит, самый старший разряд
            // имеет самый большой номер в массиве
            int i = 0;
            int count = item.Count;
            while ( (count - i - 1) > 0 && item[count - i - 1] == 0)
            {
                i++;
            }
            item.RemoveRange(count - i, i);
        }

        // Обычное умножение
        private List<int> naive_mul(List<int> A, List<int> B)
        {
            int A1 = GetNum(A);
            int B1 = GetNum(B);

            int resINT = A1 * B1;

            string[] resSTR = new string[1];
            resSTR[0] = resINT.ToString();
            // Приведение по модулю выполнится за счет GetList
            return GetList(resSTR).First();
        }

        // Умножение методом Карацубы
        private List<int> karatsuba_mul(List<int> A, List<int> B)
        {
            RemoveNulls(ref A);
            RemoveNulls(ref B);

            int max = 9;

            if (A.Count + B.Count < max)
            {
                return naive_mul(A, B);
            }

            int count = A.Count;
            if (B.Count > count)
            {
                count = B.Count;
            }
            if (count % 2 != 0)
            {
                count++;
            }
            AddNulls(ref A, count);
            AddNulls(ref B, count);

            List<int> A1 = new List<int>(A.GetRange(0, count / 2));
            List<int> A2 = new List<int>(A.GetRange(count / 2, count / 2));
            List<int> B1 = new List<int>(B.GetRange(0, count / 2));
            List<int> B2 = new List<int>(B.GetRange(count / 2, count / 2));

            List<int> sumA = Sum(A1, A2);
            List<int> sumB = Sum(B1, B2);

            RemoveNulls(ref A1);
            RemoveNulls(ref A2);
            RemoveNulls(ref B1);
            RemoveNulls(ref B2);
            
            RemoveNulls(ref sumA);
            RemoveNulls(ref sumB);
            
            List<int> MUL1 = karatsuba_mul(A1, B1);
            List<int> MUL2 = karatsuba_mul(A2, B2);
            List<int> MUL3 = karatsuba_mul(sumA, sumB);
            
            MUL3 = Dif(MUL3, Sum(MUL1, MUL2));
            
            RemoveNulls(ref MUL1);
            RemoveNulls(ref MUL2);
            RemoveNulls(ref MUL3);

            List<int> result = new List<int>();
            result.Add(0);
            if (!(MUL2.Count == 1 && MUL2.First() == 0))
            {
                for (int i = 0; i < count; i++)
                {
                    MUL2.Insert(0, 0);
                }
            }
            if (!(MUL3.Count == 1 && MUL3.First() == 0))
            {
                for (int i = 0; i < count / 2; i++)
                {
                    MUL3.Insert(0, 0);
                }
            }

            result = Sum(result, MUL2);
            result = Sum(result, MUL3);
            result = Sum(result, MUL1);
            
            RemoveNulls(ref result);
                        
            return Module(result);
        }

        private List<int> Module(List<int> item)
        {
            RemoveNulls(ref item);
            RemoveNulls(ref m);

            bool minus = false;

            if (item[item.Count - 1] < 0)
            {
                minus = true;
                item[item.Count - 1] *= (-1);
            }
            List<int> result = Division(item);
            if (minus)
            {
                result = Dif(m, result);
            }
            return result;
        }
        private List<int> Division(List<int> item)
        {
            int count = m.Count;
            List<int> result;

            if (Compare(item, m) < 0)
            {
                result = item.GetRange(0, item.Count);
                RemoveNulls(ref result);
                return result;
            }
            result = item.GetRange(item.Count - count, count);

            while (count < item.Count)
            {                
                if (Compare(result, m) < 0)
                {
                    count++;
                    result.Insert(0, item[item.Count - count]);
                    RemoveNulls(ref result);
                }
                while (Compare(result, m) >= 0)
                {
                    result = Dif(result, m);
                }
            }
            if (Compare(result, m) >= 0)
            {
                result = Dif(result, m);
            }
            RemoveNulls(ref result);
            return result;
        }
        private int Compare(List<int> A, List<int> B)
        {
            int count = A.Count;
            if (B.Count > count)
            {
                count = B.Count;
            }
            AddNulls(ref A, count);
            AddNulls(ref B, count);

            for (int i = count-1; i >= 0; i--)
            {
                if (A[i] < B[i])
                    return -1;
                if (A[i] > B[i])
                    return 1;                 
            }
            return 0;            
        }


        private string[] GetText(TextBox item)
        {
            return item.Lines;
        }
        private List<List<int>> GetList(string[] item)
        {
            List<List<int>> list = new List<List<int>>();

            for (int i = 0; i < item.Count(); i++)
            {
                if (item[i] == "")
                {
                    continue;
                }
                List<int> tmp = new List<int>();
                int j = 0;

                if (item[i][j] == '-') {
                    j++;
                    tmp.Add((int)(item[i][j] - 48)*(-1));
                    j++;
                }

                for ( ; j < item[i].Length; j++)
                {
                    tmp.Add((int)(item[i][j] - 48));
                }

                tmp.Reverse();
                list.Add(Module(tmp));
            }
            return list;
        }

        // Перевод вектора в число
        private int GetNum(List<int> A)
        {
            int result = 0;
            bool minus = false;

            RemoveNulls(ref A);

            if (A[A.Count - 1] < 0)
            {
                minus = true;
                A[A.Count - 1] *= -1;
            }

            for (int i=0; i < A.Count; i++)
            {
                result += A[i] * Power(10, i);
            }

            if (minus)
                return result * (-1);
            return result;
        }

        // Возведение числа p в степень k
        private int Power(int p, int k)
        {
            int result = 1;
            for (int i = 0; i < k; i++)
            {
                result *= p;
            }
            return result;
        }
    }
}

