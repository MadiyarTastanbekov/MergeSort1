using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
	class Program
	{

		static void Main(string[] args)
		{
			int[] A = new int[] { 5, 2, 4, 6, 1, 3, 2, 6 };
			Console.WriteLine("Не сортированный массив: ");
			foreach (int element in A)
				Console.Write(element + " ");
			Console.WriteLine();
			Sort(A);
			Console.WriteLine($"Отсортированный массив:");
			string mass = "";//Создал строку
			foreach (int element in A)
				mass += Convert.ToString(element) + " ";//конвертировав добавляем элементы  к строку
			string[] words = mass.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);//удалили все пустые подстроки
			Console.Write(string.Join(",", words));// к массиву words  между элементам добавил запятую  с помощью метода  string.Join
			Console.ReadLine();
		}
		/// <summary>
		/// Создал новый массив
		/// </summary>
		static int[] masA;
		/// <summary>
		/// 
		/// </summary>
		/// <param name="A">массив</param>
		/// <param name="p">стартовый элемент </param>
		/// <param name="q">середина массива</param>
		/// <param name="r">конец элемента </param>
		static void Merge(int[] A, int p, int q, int r)
		{
			int left = p;//левый массив
			int right = q + 1;//правый массив
			int length = r - p + 1;//длина массива
			for (int i = 0; i < length; i++)
			{
				if (right > r || (left <= q && A[left] < A[right]))
				{
					masA[i] = A[left];
					left++;
				}
				else
				{
					masA[i] = A[right];
					right++;
				}
			}
			for (int i = 0; i < length; i++)
				A[i + p] = masA[i];
		}
		/// <summary>
		/// Использовал рекурсию
		/// </summary>
		/// <param name="A">масив</param>
		/// <param name="p">стартовый элемент</param>
		/// <param name="r"> конец элемента </param>
		static void Sort(int[] A, int p, int r)
		{
			if (p < r)
			{
				int q = (p + r) / 2;
				Sort(A, p, q);
				Sort(A, q + 1, r);
				Merge(A, p, q, r);
			}
		}
		/// <summary>
		/// Сортируем элементы начинаем по индексу 1- элемента
		/// </summary>
		/// <param name="A"></param>
		static void Sort(int[] A)
		{
			masA = new int[A.Length];
			Sort(A, 1, A.Length - 1);
		}
	}
}
