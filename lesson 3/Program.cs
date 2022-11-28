using System;
using System.ComponentModel;

ImplicitConversation();
ExplicitConversation();
ProcessBytes();
DeclareImplictVars();


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
