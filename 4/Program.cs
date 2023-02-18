// // Задача 37:Найдите произведение пар чисел в одномерном массиве.
// Парой считаем первый и последний элемент, второй и предпоследний и т.д.
// Результат запишите в новом массиве.
// [1 2 3 4 5] -> 5 8 3
// [6 7 3 6]-> 36 21

int[] arrayFiller(){ 
       Console.WriteLine("Please input numbers: ");
       int[] array = new int[9];
       for(int i = 0; i<array.Length; i++)
           array[i] = int.Parse(Console.ReadLine());
       return array;
    }  
    int[] maxAndMinSumCalculator(int[] array){
        int i = 0;
        int j = array.Length-1;
        int x = (array.Length+array.Length%2)/2;
        int[] resultArray =new int[x];
        for(;x-1<=j ; i++, j--)
           resultArray[i] = array[i]*array[j];  
        return  resultArray;  
    }
    
    Console.Clear();
    Console.WriteLine(String.Join(", ", maxAndMinSumCalculator(arrayFiller())));
