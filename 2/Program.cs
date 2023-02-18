
//     Задача 36: Задайте одномерный массив,
// заполненный случайными числами. Найдите сумму элементов, стоящих на нечётных позициях.
// [3, 7, 23, 12] -> 19
// [-4, -6, 89, 6] -> 0
    int[] arrayFiller(){ 
       Console.WriteLine("Please input numbers: ");
       int[] array = new int[5];
       int x =0;
       for(int i = 0; i<array.Length; i++)
           array[i] = int.Parse(Console.ReadLine());
       return array;
    }  
    int calculateSumNumbers(int[] array){
        int sum = 0;
        for(int i = 0; i<array.Length; i++){
            if((i+1)%2 == 0) sum+=array[i];
        }
        return sum;
    }
    
    Console.Clear();
    Console.WriteLine($" Result: {calculateSumNumbers(arrayFiller())}");


