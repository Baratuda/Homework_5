
   // Во время недавних раскопок на Марсе были обнаружены листы бумаги с таинственными символами на них. 
   // После долгих исследований учёные пришли к выводу, что надписи на них на самом деле могли быть обычными числовыми равенствами.
   // Кроме того, из других источников было получено веское доказательство того, что марсиане знали только три операции - сложение, 
   // умножение и вычитание (марсиане никогда не использовали «унарный минус»: вместо «-5» они писали «0-5»). Также ученые доказали,
   // что марсиане не наделяли операции разным приоритетом, а просто вычисляли выражения (если в них не было скобок) слева направо: 
   // например, 3+3*5 у них равнялось 30, а не 18. К сожалению, символы арифметических действий стерлись. Например, если была запись 
   // «18=7 (5 3) 2», то возможно восстановить эту запись как «18=7+(5-3)*2». Требуется написать программу, находящую требуемую расстановку 
   // знаков или сообщающую, что таковой не существует.
   // Входные данные
   // Первая строка входного файла INPUT.TXT состоит из натурального числа, не превосходящего 230, знака равенства, и последовательности 
   // натуральных чисел (не более десяти), произведение которых также не превосходит 230. Некоторые группы чисел (одно или более) могут быть 
   // окружены скобками. Длина входной строки не будет превосходить 80 символов, и других ограничений на количество и вложенность скобок нет.
   //  Между двумя соседними числами, не разделенными скобками, всегда будет хотя бы один пробел, во всех остальных местах может быть любое 
   //  (в том числе и 0) число пробелов (естественно, внутри числа пробелов нет).
   // Выходные данные
   // В выходной файл OUTPUT.TXT необходимо вывести одну строку, содержащую полученное равенство (т.е., исходное равенство со вставленными 
   // знаками арифметических действий без лишних пробелов). В случае если требуемая расстановка знаков невозможна, вывести строку, состоящую 
   // из единственного числа «-1». Выходная строка не должна содержать пробелов.
    string[] stringSeparatorForChars(){ 
       Console.Write("Please input string: ");    
       char[] delimiterChars = { ' ', '=' };
       return Console.ReadLine().Split(delimiterChars, System.StringSplitOptions.RemoveEmptyEntries);
    }
    //Auxiliary method for performing the calculation
    int calculationExecutionMethod(int number1, int number2, int numberOfOperation){
        if(numberOfOperation==1) return number1+number2;
        if(numberOfOperation==2) return number1-number2;
        if(numberOfOperation==3) return number1*number2;
        return 0;
    }
    //Передает в вспомгтельный метод который вычисляет результат двух чисел, который получает на вход массив чисел и массив 
    //с кодами операторов 1 - (+), 2 - (-), 3 - (*) и возвращает результат который при сравневании с введенным с консоли числом.
    // True - если равно и False - если не равен.
    bool calculateResultMethod(int[] numbersArray, int[] operatorsArray, int result){
       int numbersarrayLength = numbersArray.Length-1;
       int result2 = numbersArray[0];
       for(int i = 0; i<operatorsArray.Length; i++)
          result2 = calculationExecutionMethod(result2, numbersArray[i+1], operatorsArray[i]); 
       return result2==result?true:false;
    }
    //Этот метод меняет код в массиве с кодами операторов. Например 1-й вызов в массиве исостоящим из 3-х кодов операторов
    // 111 -> 112 и возвращает этот код обратно.
    int[] calculationMethod(int[] iterators){
        int sumCount = 0;
        int arraySize = iterators.Length-1;
        for(int i = arraySize; i>=0; i--){
          if(iterators[i]<3 && sumCount==0){ 
             iterators[i]++;
             break;
          }else if(iterators[arraySize]==3){
             iterators[arraySize-1]++;
             iterators[arraySize]=1;
             sumCount++;
          }else if(iterators[i]>3){
             iterators[i]=1;
             iterators[i-1]++;
             break;
          }
        }
        return iterators;
    } 
     //Заполняет массив оераторов занчениями равными 1.
     int[] arrayFiller(int size){
         int[] array = new int[size];
         Array.Fill(array,1);
         return array;
     }
     //Получает на вход все компоненты для сбора результирующей строки в случае если возможная последовательность операторов найдена
     // и собирает получившуюся строку.
     string getResult(string[] numbersArray, int[] operationsArray, int result){
         string str = result.ToString()+"=";
         string operation = " ";
         for(int i = 0; i<operationsArray.Length; i++){
             if(operationsArray[i]==1) operation="+";
             if(operationsArray[i]==2) operation="-";
             if(operationsArray[i]==3) operation="*";
             str = str+numbersArray[i]+operation;
         }
         return str+numbersArray[numbersArray.Length-1];
     }
     //Метод удаляет пробелы между скобками и числом в случае если пользователь поставил между ними пробел.
     string[] test(string[] array){
         for(int i = 0; i<array.Length-1; i++){
             if(array[i].Equals("("))
                 array[i+1] ="("+array[i+1];
             if(array[i].Equals(")"))
                 array[i-1] =array[i-1]+ ")";
         }
         return array.Where(e=> !e.Equals("(") && !e.Equals(")")).ToArray();
     }
        Console.Clear();
        char[] charsToTrim = {')', '('};
        string[] arrayWithBrakets = test(stringSeparatorForChars());
        int[] array = Array.ConvertAll(arrayWithBrakets, e => int.Parse(e.Trim(charsToTrim)));
        int result = array[0];
        array = array.Where((e, i) => i != 0).ToArray();//удаляет первое число котоое является результатомю
        arrayWithBrakets = arrayWithBrakets.Where((e, i) => i != 0).ToArray();//удаляет первое число котоое является результатомю
        
        int[] sequenceArray = arrayFiller(array.Length-1);//создает массив с операторами заполненный 1.
        bool result123 = false;
        for(int i = 1; i<Math.Pow(3,array.Length-1); i++){
            result123 = calculateResultMethod(array, calculationMethod(sequenceArray), result);
            if(result123) break;
        }
        string  str = result123 ? getResult(arrayWithBrakets,sequenceArray,result) : "-1";
        Console.Write(str);

// Please input string: 10 = 2 (   3 4)
// 10=2*(3+4)