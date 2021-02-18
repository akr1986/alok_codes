using System;
using System.Collections.Generic;
namespace dyanamicprog
{
    public class recursionperm
    {
        public void binaryrec(int n, string slate, List<string> lst)
        {
            if (n <= 0)
            {
                lst.Add(slate);
                return;
            }
            else
            {
                binaryrec(n - 1, slate + "0", lst);
                binaryrec(n - 1, slate + "1", lst);
            }

        }
        public void binarynumber(int n)
        {
            List<string> lst = new List<string>();
            binaryrec(n, "", lst);
            lst.ForEach(Console.WriteLine);
        }
    }
}
