using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL
{
    class BinarySearch
    {
        public void Run()
        {
            Console.WriteLine("Run");

            List<int> my_list = new List<int> { 1, 3, 5, 7, 9 };

            int nGetIndex = binary_search(my_list, -1);
        }

        // 返回一个Index值.
        public int binary_search(List<int> lstValues, int item)
        {
            int nRtn = -1;


            int low = 0;
            int high = lstValues.Count - 1;
            int mid = 0;
            int guess = 0;

            // 判断没有超过极限值时 继续处理.
            while(low <= high)
            {
                mid = (low + high) / 2;
                guess = lstValues[mid];

                if(guess == item)
                {
                    // 返回的是index值.
                    return mid;
                }
                else if(guess > item)
                {
                    // 中间切出的值大于输入值 说明值在中间值的左侧
                    // 那么提取左侧小值的区间.
                    high = mid - 1;
                }
                else
                {
                    // 中间切出的值小于输入值 说明值在中间值得右侧
                    // 提取右侧大值的区间
                    low = mid + 1;
                }

            }


            return nRtn;
        }
    }
}
