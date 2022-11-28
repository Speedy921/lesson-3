using System;
using System.ComponentModel;

ImplicitConversation();
ExplicitConversation();
ProcessBytes();
DeclareImplictVars();
DeclareImplicitNumerics();
LinqQueryOverInts();


static void ImplicitConversation()
{
    Console.WriteLine("*****Fun with type conversations*****");
    //сложить две переменные типа short и вывести результат.
    short numb1 = 9, numb2 = 10;
    Console.WriteLine(" {0} + {1} = {2}", numb1, numb2, Add(numb1, numb2));
    Console.ReadLine();
    static int Add(int x, int y)
    {
        return x + y;
    }
    //максимальное значение типа int больше нежели тип short, поэтому это код работает без ошибок
    //компилятор неявно расширяет значение short до типа int 
}

static void ExplicitConversation()
{
    Console.WriteLine("*****Fun with conversation*****");
    short numb1 = 30000, numb2 = 30000;
    //явно привести int к short (и разрешить потерю данных).
    short answer = (short)Add(numb1, numb2);
    Console.WriteLine(" {0} + {1} = {2}", numb1, numb2, answer);
    NarrowingAttempt();
    Console.WriteLine();
}

static int Add(int x, int y)
{
    return x+y;
}

static void NarrowingAttempt()
{
    byte myByte = 0;
    int myInt = 200;

    //Явно привести int к byte (без потери данных)
    myByte = (byte)myInt;
    Console.WriteLine("Value of myByte: {0}", myByte);
}

//использованеи checked

static void ProcessBytes()
{
    byte b1 = 100;
    byte b2 = 250;

    // Сообщить компилятору о необходимости добавления 
    // кода CIL, необходимого для генерации исключения, если  возникает 
    //переполнение или потеря значимости.

    try
    {
        byte sum = checked((byte)Add(b1, b2));
        Console.WriteLine("sum = {0}", sum);
    }
    catch (OverflowException ex)
    {
        Console.WriteLine(ex.Message);
    }
}

static void DeclareImplictVars()
{
    //неявно типизированые локальные переменные

    var myInt = 0;
    var myBool = true;
    var myString = "Time, marches on...";

    //вывести имена лежащих в основе типов
    Console.WriteLine("myInt is a: {0}", myInt.GetType().Name);
    //вывод типа myInt

    Console.WriteLine("myBool is a: {0}", myBool.GetType().Name);
    //вывод типа myBool

    Console.WriteLine("myString is a: {0}", myString.GetType().Name);
    //вывод типа myString
}

//неявные обьявления чисел
static void DeclareImplicitNumerics()
{

    //Неявно типизированные числовые переменные.
    var myUInt = 0u;
    var myInt = 0;
    var myLong = 0L;
    var myDouble = 0.5;
    var myFloat = 0.5F;
    var myDecimal = 0.5M;

    //вывод лежащего в основе типа.
    Console.WriteLine("myUInt is a: {0}", myUInt.GetType().Name);
    Console.WriteLine("myInt is a: {0}", myInt.GetType().Name);
    Console.WriteLine("myLong is a: {0}", myLong.GetType().Name);
    Console.WriteLine("myDouble is a: {0}", myDouble.GetType().Name);
    Console.WriteLine("myFloat is a: {0}", myFloat.GetType().Name);
    Console.WriteLine("myDecimal is a: {0}", myDecimal.GetType().Name);
}

//использование var в LINQ
static void LinqQueryOverInts()
{
    int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };
    
    //запрос LINQ

    var subset = from i in numbers where i < 10 select i;
    Console.WriteLine("Values in subset: ");
    foreach (var i in subset)
    {
        Console.Write("{0}", i);
    }
    Console.WriteLine();
    Console.WriteLine("Subset is a: {0}", subset.GetType().Name);
    Console.WriteLine("Subset is defined in: {0}", subset.GetType().Namespace);

}