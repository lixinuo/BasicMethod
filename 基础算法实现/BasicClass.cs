using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 基础算法实现
{
    public class BasicClass
    {

        //冒泡排序  比较相邻的元素，如果第一个比第二个大，则交换位置
        public static void BubbleSort(int[] array)
        {
            int temp;
            bool flag;
            for (int i = array.Length - 1; i >= 1; i--)
            {
                flag = false;
                for (int j = 1; j <= i; j++)
                {
                    if (array[j - 1] > array[j])
                    {
                        temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;
                        flag = true;
                    }
                }
                if (!flag)
                {
                    return;
                }
            }
        }

        //快速排序 以一个数为基准，小于的放到左边，大于的放到右边，递归实现
        public static void QuickSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int index = Partition(array, low, high);
                QuickSort(array, low, index - 1);
                QuickSort(array, index + 1, high);
            }
        }

        public static int Partition(int[] array, int low, int high)
        {
            int i = low;
            int j = high;
            int temp = array[low];

            while (i != j)
            {
                //先判断右半部分是否有小于temp的数，如果有则交换到array[i]
                while (i < j && temp < array[j])
                {
                    j--;
                }
                if (i < j)
                {
                    array[i++] = array[j];
                }

                //判断左半部分是否有大于temp的数，如果有则交换到array[j]
                while (i < j && temp > array[i])
                {
                    i++;
                }
                if (i < j)
                {
                    array[j--] = array[i];
                }
            }
            array[i] = temp;

            return i;
        }

        //查找算法
        //顺序查找
        public static int SimpleSearch(int[] array, int key)
        {
            int result = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == key)
                {
                    result = i + 1;
                    break;
                }
            }
            return result;
        }

        //二分查找
        public static int BinarySearch(int[] array, int key)
        {
            int low = 0;
            int high = array.Length - 1;
            int mid = -1;

            while (low <= high)
            {
                mid = (low + high) / 2;
                if (array[mid] > key)
                {
                    high = mid - 1;
                }
                else if (array[mid] < key)
                {
                    low = mid + 1;
                }
                else
                {
                    return mid + 1;
                }
            }
            return mid;
        }

        public static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + "  ");
            }
            Console.WriteLine("");
        }

    }
}
