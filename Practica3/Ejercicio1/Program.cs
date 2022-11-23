using System;

public class Ejercicio1 
{
  public static void Main (string[] args) {
    bool loop = true;
    string confirmacion;
    int x_1 = 0, x_2 = 0, t_i = 0;
    
    do{

      Console.Clear();
      try{
        Console.WriteLine("Programa para calcular una ecuación de segundo grado de la forma Ax^2 + Bx + C = 0\n");
        Console.WriteLine ("Ingrese los valores de cada x");
        Console.Write("X^2: ");
        x_2 = Convert.ToInt32(Console.ReadLine());
        Console.Write("X^1: ");
        x_1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Termino independiente: ");
        t_i = Convert.ToInt32(Console.ReadLine());
        
        //CONFIRMACION
        Console.Write("\n¿Su ecuación de segundo grado es la siguiente?\n\t{0}x^2 + {1}x^1 + {2} = 0\n\n[Si/No]: ", x_2, x_1, t_i);
  
        confirmacion=Console.ReadLine();
  
        if (confirmacion == "no" || confirmacion == "No"){
          Console.WriteLine("Repitiendo...");
          
        }else{
          loop = false;
        }
        
      }catch(Exception ex){//en caso de que usuario coloque caracteres
        Console.WriteLine("\nIntroduzca solo números reales\n\tError: {0}\n\nPulse cualquier tecla para continuar...", ex.GetType().Name);
        Console.ReadLine();
      }

    }while(loop!=false);

    double dis = Math.Pow(x_1, 2) - (4 * x_2 * t_i);
    double[] resultados = resolverEcuacion(x_2, x_1, t_i);

    Console.Clear();
    Console.WriteLine("------------------- RAICES -------------------");
    if(resultados[0] != resultados[1] && dis >= 0){ // 2 resultados numeros reales

      for(int j=0 ; j < 2 ; j++ ){
        Console.WriteLine("\tResultado x{0}: {1}", j+1, resultados[j]); // si solo tiene uno es que se ingreso una ecuacion lineal
      }

    }else if(dis < 0){//solucion imaginaria

        Console.WriteLine("Solución compleja");
        Console.WriteLine("\tResultado x1: {0} + {1} i ", resultados[0], resultados[1]);
        Console.WriteLine("\tResultado x2: {0} - {1} i ", resultados[0], resultados[1]);
        /*
         POLINOMIO A PROBAR
            x² + 1 = 0
            Solución: x_1 = i; x_2 = -i
        */
    }else{// Resultado numeros reales solución doble
      Console.WriteLine("\tResultado x1 y x2 : {0}", resultados[0]);
    }
  }

  public static double[] resolverEcuacion(int a, int b, int c){
    double[] resultados = new double[2];
    double dis;

    //calcular discriminante

    if (a != 0){
        dis = Math.Pow(b, 2) - (4 * a * c);

        if(dis < 0){//no tiene solucion real, solucion caso complejo

          resultados[0]= ((double)-b)/(2 * (double)a);//parte real
          resultados[1]=Math.Sqrt((-1) * dis)/(2 * (double)a); //parte imaginaria, -1 hace posible la resolucion

        }else{//ecuacion general

          try{

            resultados[0] = ((-1 * b) + Math.Sqrt(dis))/(2 * a);
            resultados[1] = ((-1 * b) - Math.Sqrt(dis))/(2 * a);

          }catch(Exception ex){
            Console.WriteLine("Ha ocurrido un error al calcular las raices, compruebe su ecuación");
            Console.WriteLine("Error: {0}", ex);
          }
        }
    }else {//ecuacion sin termino cuadratico
        resultados[0] = (-1 * c)/(b);
        resultados[1] = 0;
    }
    return resultados;
  }
}
