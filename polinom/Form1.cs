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
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {



        }
        private List<int> result()
        {
            List<List<int>> a = GetNum(GetText(Owner.Controls["K"] as TextBox));
            List<int> b = GetNum(GetText(Owner.Controls["B"] as TextBox)).First();
            List<List<int>> p = new List<List<int>>();

            int n = a.Count;

            p.Add(a[0]);

            for (int i = 1; i < n; i++)
            {
                p[i] = Sum(karatsuba_mul(p[i - 1], b), a[n - i]);
            }
            return p.Last();
        }

        private List<int> Sum(List<int> A, List<int> B)
        {
            int count = A.Count;
            if (B.Count > count)
            {
                count = B.Count;
                MakeEqual(ref A, count);
            }
            MakeEqual(ref B, count);

            List<int> res = new List<int>(count);
            bool f = false;

            for (int i = 0; i < count; i++)
            {

                res[i] = (A[i] + B[i]) % 10;
                if (f)
                {
                    res[i]++;
                }

                f = Convert.ToBoolean((A[i] + B[i]) / 10);
            }

            if (f)
            {
                res.Insert(0, 1);
            }
            return res;
        }

        private void MakeEqual(ref List<int> num, int count)
        {
            for (int i = 0; i < count - num.Count; i++)
            {
                num.Insert(0, 0);
            }
        }
        private List<int> naive_mul(List<int> A, List<int> B) {
            string tmp = A.ToString();
            int A1 = Int32.Parse(tmp);

            tmp = B.ToString();
            int B1 = Int32.Parse(tmp);

            int resINT = A1 * B1;
            
            string[] resSTR = new string[1];
            resSTR[0].Insert(0, resINT.ToString());
            return GetNum(resSTR).First();
        }
        private List<int> karatsuba_mul(List<int> A, List<int> B) {

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
            MakeEqual(ref A, count);
            MakeEqual(ref B, count);

            List<int> A1 = new List<int>(A.GetRange(0,count/2));
            List<int> A2 = new List<int>(A.GetRange(count/2, count));
            List<int> B1 = new List<int>(B.GetRange(0, count / 2));
            List<int> B2 = new List<int>(B.GetRange(count / 2, count));

            List<int> MUL1 = karatsuba_mul(A1, B1);
            List<int> MUL2 = karatsuba_mul(A2, B2);
            List<int> MUL3 = karatsuba_mul(Sum(A1,A2), Sum(B1,B2));

            RemoveNulls(ref MUL1);
            RemoveNulls(ref MUL2);
            RemoveNulls(ref MUL3);

            List<int> res = new List<int>();
            res.AddRange(MUL1);


        }

        private void RemoveNulls(ref List<int> item)
        {
            int i = 0;
            while (item[i] == 0)
            {
                i++;
            }
            item.RemoveRange(0, i);
        }
        private string[] GetText(TextBox item)
        {
            return item.Lines;
        }
        private List<List<int>> GetNum(string[] item)
        {
            List<List<int>> number = new List<List<int>>();
            List<int> tmp = new List<int>();

            for (int i = 0; i < item.Count(); i++)
            {
                for (int j = 0; j < item[i].Length; j++)
                    tmp.Add((int)(item[i][j] - 48));

                number.Add(tmp);
                tmp.Clear();
            }
            return number;
        }
    }
}

