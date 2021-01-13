using System;
using System.Collections.Generic;
namespace dyanamicprog
{
    class MainClass
    {
        public static Dictionary<int, int> dic = new Dictionary<int, int>();
        public static int fibtopdown(int n)
        {
            if (dic.ContainsKey(n))
                return dic[n];
            if (n == 0 || n == 1)
                return n;
            else
            {
                dic[n]= (fibtopdown(n - 1) + fibtopdown(n - 2));
                return dic[n];
            }
                
        }
        public static int fubbottomup(int n)
        {
            int[] tab = new int[3];
            tab[0] = 0;
            tab[1] = 1;
            for(int i=2;i<=n;i++)
            {
                tab[i%3] = tab[(i - 1) % 3] + tab[(i - 2) % 3];
            }
            return tab[n%3];
        }
        public static int subsetcount(int n,int k)
        {
            if (k == 0)
                return 1;
            if (n == k)
                return 1;
            return subsetcount(n - 1, k) + subsetcount(n - 1, k - 1);
        }
        public static int subsetcountdp(int n,int k)
        {
            int[,] tab = new int[n + 1, k + 1];
            for (int i = 0; i <= n; i++)
                tab[i, 0] = 1;
            for (int i = 0; i <= k; i++)
                tab[i, i] = 1;

            for(int row=2;row<=n;row++)
            {
                for(int col=1;col<= Math.Min(row,k);col++)
                {
                    tab[row, col] = tab[row - 1, col] + tab[row - 1, col - 1];
                }
            }           

            return tab[n, k];
        }
        public static int wordtrace(int m,int n)
        {

            int[,] tab = new int[m,n];
            for (int i = 0; i < m; i++)
                tab[i, 0] = 1;
            for (int i = 0; i < n; i++)
                tab[0, i] = 1;

            for(int row=1;row<m;row++)
            {
                for(int col=1;col<n;col++)
                {
                    tab[row, col] = tab[row - 1, col] + tab[row, col - 1];
                }
            }
            return tab[m - 1, n - 1];

        }

        public static int maximumsumpath(int[,] grid,int m,int n)
        {
            int[,] tab = new int[m, n];
            List<(int, int)> path = new List<(int, int)>();
            List<(int, int)> path1 = new List<(int, int)>();
            tab[0, 0] = grid[0, 0];
            path.Add((0, 0));
            path1.Add((0, 0));
            for (int i = 1; i < m; i++)
                tab[i, 0] = tab[i - 1, 0] + grid[i, 0];
            for (int i = 1; i < n; i++)
                tab[0, i] = tab[0, i-1] + grid[0, i];
            for(int row=1; row<m;row++)
            {
                for(int col=1;col<n;col++)
                {
                    if (tab[row - 1, col] >= tab[row, col - 1])
                        path.Add((row - 1, col));
                    else
                        path.Add((row , col-1));
                    path1.Add((row, col));
                    tab[row, col] = grid[row, col] + Math.Min(tab[row - 1, col], tab[row, col - 1]);
                }
            }
            for (int i = 0; i < path.Count; i++)
                Console.WriteLine("{0},{1}-> {2},{3}", path[i].Item1, path[i].Item2,path1[i].Item1, path1[i].Item2);
            

            return tab[m - 1, n - 1];

        }
        public static int mincost(int[] costarray,int n)
        {
            int[] tab = new int[n + 2];
            tab[0] = 0;
            tab[1] = costarray[0];
            tab[n + 1] = 0;

            for(int i=2;i<n+2;i++)
            {
                tab[i] = costarray[i - 1] + Math.Min(tab[i - 1], tab[i - 2]);
            }
            return tab[n + 1];
        }
        public static int coinchange(int val,int[] coins)
        {
            int[] tab = new int[val + 1];
            for (int i = 1; i <= val; i++)
                tab[i] = 999999;

            for(int i=1;i<=val;i++)
            {
                for(int j=0;j<coins.Length;j++)
                {
                    if(i- coins[j] >= 0)
                    tab[i] = 1 + Math.Min(tab[i], tab[i - coins[j]]);
                }
            }
            return tab[val];
        }
        public static void cutrod(int n, string slate, List<string> lst,int sum)
        {
            if (n == 1)
            {
                lst.Add(slate+"1"+"->"+ Convert.ToString(sum));
                    return;
            }
            else
            {
                for (int i = 1; i <= n - 1; i++)
                {
                    //cutrod(n - i, slate + Convert.ToString(i), lst);
                    
                    lst.Add(slate+Convert.ToString(n - i) + Convert.ToString(i)+ "->"+Convert.ToString(sum * (n - i) * i));
                    //cutrod(n - i, Convert.ToString(n -i) + Convert.ToString(i), lst);
                }

                for (int i=1;i<=n-1;i++)
                {
                    cutrod(n - i, slate + Convert.ToString(i), lst,sum*i);

                  //  lst.Add(Convert.ToString(n - i) + Convert.ToString(i));
                    //cutrod(n - i, Convert.ToString(n -i) + Convert.ToString(i), lst);
                }
            }
        }
        static long max_product_from_cut_pieces(int n)
        {
            long[] tab = new long[n + 1];
            int m = 1046035320;
            int n1 = m*10;
            Console.WriteLine(n1);
            //tab[1] = 1;
            //int maxval = 0;
            for (int i = 1; i <= n; i++)
            {
                long maxval = 0;
                for (int j = 1; j < i; j++)
                {
                     maxval = Math.Max(maxval, j * (i - j));
                     maxval = Math.Max(maxval, j * tab[i - j]);
                    //maxval= Math.Max(maxval, Math.Max((i - j) * j, tab[i - j] * j));
                }
                tab[i] = maxval;
            }            
            return tab[n];
        }
        static long max_product_from_cut_pieces1(int n)
        {
            /*
             * Write your code here.
             */
            if (n <= 0)
                throw new ArgumentException("Inout is not valid " + nameof(n));

            long[] cuts = new long[n + 1];
            cuts[0] = 0;

            for (var i = 1; i <= n; i++)
            {
                long maxValue = 0;

                for (var higherCut = 1; higherCut <= n / 2; higherCut++)
                {
                    if (i < higherCut)
                        continue;

                    var cutRemainder = i - higherCut;

                    maxValue = Math.Max(maxValue, Math.Max(cutRemainder * higherCut, higherCut * cuts[cutRemainder]));
                }
                cuts[i] = maxValue;
            }

            return cuts[n];
        }
        public static int rodcut(int n,int[] prices)
        {
            int[] tab = new int[n + 1];
            List<int> lst= new List<int>();
            tab[0] = 0;
            tab[1] = prices[0];
            int k = 0;
            lst.Add(0);
            lst.Add(1);
            for(int i=2;i<=n;i++)
            {
                int premaxval = 0;
                int maxval = 0;
                for(int j=1;j<=i;j++)
                {
                    maxval = Math.Max(maxval,prices[j-1] + tab[i-j]);
                    if (premaxval != maxval)
                        k = i-j;
                    premaxval = maxval;
                }
                lst.Add(k);                
                tab[i] = maxval;
            }
            return tab[n];
        }
        public static void Main(string[] args)
        {
            //Console.WriteLine(fibtopdown(44));
            //Console.WriteLine(fubbottomup(44));
            //Console.WriteLine(subsetcount(38,12));
            // Console.WriteLine(subsetcountdp(38, 12));
            //Console.WriteLine(wordtrace(5, 5));
            //  int[,] grid = new int[3, 3] { { 1, 2, 1 }, { 1, 2, 1 }, { 1, 9, 1 } };
            //  int[] costarray = new int[5] { 5, 7, 13, 9, 0 };
            // Console.WriteLine(maximumsumpath(grid,3,3));
            // Console.WriteLine(mincost(costarray,4));
            // int[] coins = new int[3]{1, 2, 11};
            // Console.WriteLine(coinchange(11, coins));
            List<string> lst = new List<string>();
            int n = 8;
         
           //  cutrod(n, "", lst,1);
              Console.WriteLine("output");
            //  lst.ForEach(Console.WriteLine);
            //Console.WriteLine(max_product_from_cut_pieces(n));
            // Console.WriteLine(max_product_from_cut_pieces1(n));
            int[] prices = new int[] { 1, 5, 8, 9, 10, 17, 17, 20 };
            Console.WriteLine(rodcut(n,prices));
        }
    }
}
