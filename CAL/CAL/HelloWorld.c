#include <stdio.h>

#define Cutoff (3)

// 交换两个值的C语言写法
void Swap(int *a, int *b)
{
	int tmp = *a;

	*a = *b;

	*b = tmp;
}

// 插入排序Done
void InsertionSort(int A[], int N)
{
	int j, P;
	int Tmp;

	// 进行多少轮总的遍历循环 这和真个数组的总数有关.
	for (P = 1; P < N; P++)
	{
		// 当前对P位置进行处理 处理的数据集只和P和P之前位置的值有关.
		Tmp = A[P];

		// j是个预想放置位置 需要和j-1的值进行比较 看一下哪个值大.
		// 大的值进行前移来留出预想判定位置.

		for (j = P; j > 0 && A[j - 1] > Tmp; j--)
		{
			A[j] = A[j - 1];
		}

		// 感觉是找到一个合适的输入位置.
		// 目前就是找j的插入位置的值.
		A[j] = Tmp;
	}
}

// 做个排序
int Median3(int A[], int Left, int Right)
{
	int Center = (Left + Right) / 2;

	if (A[Left] > A[Center])
	{
		Swap(&A[Left], &A[Center]);
	}

	if (A[Left] > A[Right])
	{
		Swap(&A[Left], &A[Right]);
	}

	if (A[Center] > A[Right])
	{
		Swap(&A[Center], &A[Right]);
	}

	Swap(&A[Center], &A[Right - 1]);

	return A[Right - 1];
}

void Qsort(int A[], int Left, int Right)
{
	int i, j;
	int Pivot;

	// 大于4个元素用快排
	if (Left + Cutoff <= Right)
	{
		Pivot = Median3(A, Left, Right);

		i = Left;
		j = Right - 1;

		for (;;)
		{
			while (A[++i] < Pivot) {}
			while (A[--j] > Pivot) {}

			if (i < j)
			{
				Swap(&A[i], &A[j]);
			}
			else
			{
				break;
			}
		}

		Swap(&A[i], &A[Right - 1]);

		Qsort(A, Left, i - 1);
		Qsort(A, i + 1, Right);
	}
	else
	{
		// 小于4个元素用插入
		InsertionSort(A + Left, Right - Left + 1);
	}
}

int main()
{
	//printf("Hello, Wolrd\n");

	//int A[] = { 34, 8, 64, 51, 32, 21};


	//InsertionSort(A, 6);

	//printf("Sort Done\n");

	//int a = 1;
	//int b = 2;

	//Swap(&a, &b);

	int A[] = { 8, 1, 4, 9, 0, 3, 5, 2, 7, 6 };

	Qsort(A, 0, 9);

	printf("Sort Done\n");
}

