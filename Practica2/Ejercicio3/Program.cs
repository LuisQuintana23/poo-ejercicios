using System;

class Ejercicio3 {
  public static void Main(string[] args)
  {
    piramide();  
  }
  public static void piramide () {
    int loop = 0;
    int num;
    do{
        Console.WriteLine("Ingresa un número:");
        
        num = int.Parse(Console.ReadLine());
        if(num < 0){
          Console.WriteLine("Error: Ingresa números positivos...\n");

        }else{
        
          loop++;
        }
    }while(loop != 1);

    for(int i=1, j=num; i<=num; i++, j--){
 
      int rep =  (2*i)-1;
      string str = new string('*', rep);
      string str_space = new string(' ', j);

      Console.WriteLine(str_space + str);
      
    }
  }
}
