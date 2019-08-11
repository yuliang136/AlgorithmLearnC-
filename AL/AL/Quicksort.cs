using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL
{
    class Quicksort
    {
        public void Run()
        {
            Console.WriteLine("Run");

            //List<int> my_list = new List<int> { 1, 3, 5, 7, 9 };

            int[] my_list = { 8, 1, 4, 9, 0, 3, 5, 2, 7, 6 };

            // 交换数据里两个元素位置

            //int x = 1;
            //int y = 2;

            //Swap(ref my_list[0], ref my_list[1]);

            Qsort(my_list, 0, my_list.Length - 1);

            Console.WriteLine("Alogorithm Done!");
        }

        private void Qsort(int[] A, int Left, int Right)
        {
            int i, j;
            int Pivot;

            Pivot = Median3(A, Left, Right);

            // i和j是哨兵index
            // Right - 1已经是Pivot的Index值.
            i = Left;
            j = Right - 1;

            for(; ; )
            {
                // ++i先加后运算 从左边开始找 如果值小于Pivot时 说明已经放好位置.
                // 一直找到一个大于或者等于Pivot的值 因为设置了Right - 1为Pivot值 所以不会向右走时产生越界
                while (A[++i] < Pivot) { }

                // 从右边开始向左找 如果值大于Pivot时 说明已经放好位置.
                // 找到一个小于或者等于Pivot的值 等待交换位置.
                while (A[--j] > Pivot) { }

                // i左边都是小于Pivot的值 j右边都是大于Pivot的值.
                // i == j时 说明..
                if(i < j)
                {
                    Swap(ref A[i], ref A[j]);
                }
                else
                {
                    // 本次Partition结束
                    break;
                }
            }

            // 还原Pivot 便于切割后进行递归排序.
            Swap(ref A[i], ref A[Right - 1]);

            Qsort(A, Left, i - 1);
            Qsort(A, i + 1, Right);

            Console.WriteLine("Alogorithm Done!");

        }

        // C#使用ref 交换两个元素
        private void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        private int Median3(int[] A, int Left, int Right)
        {
            int nRtn = 0;


            int Center = (Left + Right) / 2;

            // 取得中间Pivot的值.

            // 把左边和中间的最小值 放在Left
            if (A[Left] > A[Center])
            {
                Swap(ref A[Left], ref A[Center]);
            }

            if(A[Left] > A[Right])
            {
                Swap(ref A[Left], ref A[Right]);
            }

            if(A[Center] > A[Right])
            {
                Swap(ref A[Center], ref A[Right]);
            }

            // Hide Pivot
            Swap(ref A[Center], ref A[Right - 1]);

            return A[Right - 1];



            //return nRtn;
        }
    }
}
