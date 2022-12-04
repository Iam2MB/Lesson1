namespace Lesson1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = 100000000;
            Task1(num);
            Task2(num);

            Console.ReadKey(true);
        }

        static void Task1(int n)
        {
            DateTime start = DateTime.Now;

            float[] arr = new float[n];

            for (int i = 0; i < n ; i++)
            {
                arr[i] = 1;
            }

            for (int i = 0; i < n; i++)
            {
                arr[i] = (float)(arr[i] * Math.Sin(0.2f + i / 5) * Math.Cos(0.2f + i / 5) *
                Math.Cos(0.4f + i / 2));
            }

            DateTime finish = DateTime.Now;
            Console.WriteLine($"Инициализация массива заняла у нас:  {finish - start} сек.");
        }

        static void Task2(int n)
        {
            DateTime start = DateTime.Now;

            float[] arr = new float[n];

            Thread thread1 = new Thread(() =>
            {
                float[] arr1 = new float[n/2];

                for (int i = 0; i < arr1.Length; i++)
                {
                    arr1[i] = 1;
                }

                for (int i = 0; i < arr1.Length; i++)
                {
                    arr1[i] = (float)(arr1[i] * Math.Sin(0.2f + i / 5) * Math.Cos(0.2f + i / 5) *
                    Math.Cos(0.4f + i / 2));
                }

                Array.Copy(arr1, 0, arr, 0, arr1.Length);
            });
            
            Thread thread2 = new Thread(() =>
            {
                float[] arr2 = new float[n/2];

                for (int i = 0; i < arr2.Length; i++)
                {
                    arr2[i] = 1;
                }

                for (int i = arr2.Length; i < arr2.Length * 2-1; i++)
                {
                    arr2[i] = (float)(arr2[i] * Math.Sin(0.2f + i / 5) * Math.Cos(0.2f + i / 5) *
                    Math.Cos(0.4f + i / 2));
                }

                Array.Copy(arr2, 0, arr, arr2.Length, arr2.Length);
            });

            DateTime finish = DateTime.Now;
            Console.WriteLine($"Инициализация массива заняла у нас:  {finish - start} сек.");
        }
    }
}