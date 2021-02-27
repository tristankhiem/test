using System;
using System.Collections.Generic;
using System.Linq;

namespace C_Application
{
    class Program
    {
        static List<int> result = new List<int>();
        static void Main(string[] args)
        {
            List<int[]> arrayList = new List<int[]>();
            Console.WriteLine("Please input number of Array:");
            int numberOfArray = Convert.ToInt32(Console.ReadLine());
            int[] numberOfElementsEachArray = new int[numberOfArray];
            for (int i = 0; i < numberOfArray; i++) {
                Console.WriteLine("Please input number of elements in Array " + (i+1) + ": ");
                int numberOfElements = Convert.ToInt32(Console.ReadLine());
                numberOfElementsEachArray[i] = numberOfElements;
                int[] array = new int[numberOfElements];
                for (int j = 0; j < numberOfElements; j++) {
                    Console.WriteLine("Please input the element " + (j+1) + ": ");
                    int elements = Convert.ToInt32(Console.ReadLine());
                    array[j] = elements;
                }
                arrayList.Add(array);
            }
            

            Console.WriteLine("Data Combination Excuted: ");
            AddToCollectionRecursive(arrayList);
            int k  = 0;
            for (int i = 0; i < result.Count; i++) {
                k++;
                Console.Write(result[i] + " ");
                if (k == arrayList.Count) {
                    k  = 0;
                    Console.WriteLine("");
                }
            }
        }
        static void AddToCollectionRecursive(List<int[]> collection) {
            List<int> objectLoop = new List<int>();
            AddTo(collection, 0, 0, objectLoop);
        }

        static void AddTo(List<int[]> collection, int currentArrayIndex, int currentElementIndex, List<int> objectLoop) {
            if (currentArrayIndex >= collection.Count) {
                return;
            }
            for (var i = 0; i < collection[currentArrayIndex].Length; i ++) {
                currentElementIndex = i;
                objectLoop.Add(collection[currentArrayIndex][i]);
                if (currentArrayIndex == collection.Count - 1) {
                    result.AddRange(objectLoop);
                }
                AddTo(collection, currentArrayIndex + 1, i, objectLoop);
                // remove item each loop
                objectLoop.RemoveAt(objectLoop.Count - 1);
            }
        }
}
}
