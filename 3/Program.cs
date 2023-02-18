
//    Задача 38: Задайте массив вещественных чисел.
// Найдите разницу между максимальным и минимальным элементов массива.
// [3 7 22 2 78] -> 76
    int[] arrayFiller(){ 
       Console.WriteLine("Please input numbers: ");
       int[] array = new int[5];
       int x =0;
       for(int i = 0; i<array.Length; i++)
           array[i] = int.Parse(Console.ReadLine());
       return array;
    }  
    int maxAndMinSumCalculator(int[] array){
        int max = array[0];
        int min = array[0];
        for(int i = 0; i<array.Length; i++){
            if(max<=array[i]) max = array[i];
            else min = array[i];
        }
        return max + min;
    }
    
    Console.Clear();
    Console.WriteLine($" Result: {maxAndMinSumCalculator(arrayFiller())}");

