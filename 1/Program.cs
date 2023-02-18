// Задача 34: Задайте массив заполненный
// случайными положительными трёхзначными числами.
// Напишите программу, которая покажет количество чётных чисел в массиве.

// [345, 897, 568, 234] -> 2
    int[] arrayFiller(){ 
       Console.WriteLine("Please input numbers: ");
       int[] array = new int[5];
       int x =0;
       for(int i = 0; i<array.Length; i++){
           x = int.Parse(Console.ReadLine());
           if(x>99 && x<1000)  array[i] = x;
           else i--;
       }
       return array;
    }  
    int calculateCountNumbers(int[] array){
        int count = 0;
        foreach(int i in array){
            if(i%2 == 0) count++;
        }
        return count;
    }
    
    Console.Clear();
    Console.WriteLine($" Result: {calculateCountNumbers(arrayFiller())}");

