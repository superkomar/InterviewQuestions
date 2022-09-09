using System;
          
public class Program
{
  public class MyBase
  {
    public MyBase() { throw new Exception("lol, an exception in the cntor!"); }
    
    public static int GetValue() => 100500;
  }
  
  public class My : MyBase
  {
      public My(){}
  }
  
  public static void Main()
  {
    Console.WriteLine(My.GetValue());
  }
}
