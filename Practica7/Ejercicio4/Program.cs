class Ejercicio4 {
    public static void Main(string [] args){
        int opcion, repetir = 1, pelicula, obra, boletos, cantidadComprados = 1, cantidadComprados2 = 1;
        string nombre, direccion, apellido, numeroPaypal, funcion, contrasenaValida = "12345", contrasenaUsuario, confirmacion;
        double costoEntradasBoletos;

        Pelicula[] historialPeliculas = new Pelicula[1];
        Obra[] historialObras = new Obra[1];
        Dictionary<int, int> numeroBoletosPeliculas = new Dictionary<int,int>();
        Dictionary<int, double> costoEntradasPeliculas = new Dictionary<int,double>();
        Dictionary<int, int> numeroBoletosObras = new Dictionary<int,int>();
        Dictionary<int, double> costoEntradasObras = new Dictionary<int,double>();
        Pelicula pelicula1 = new Pelicula("Titanic", "Sala 1", "7:00pm", 69);
        Pelicula pelicula2 = new Pelicula("Jurassic World", "Sala 2", "8:30pm", 79);
        Pelicula pelicula3 = new Pelicula("Avengers Endgame", "Sala 3", "9:00pm", 89);
        Pelicula [] arrPeliculas = {pelicula1, pelicula2, pelicula3};
        Obra obra1 = new Obra("Romeo y Julieta", "Sala 4", "5:00pm", 119, "Romeo, Julieta, Mercucio, Teobaldo, Fray, etc", "Baz Luhrmann", "Verona");
        Obra obra2 = new Obra("Hamlet", "Sala 5", "3:00pm", 129, "Hamlet, Principe de dinamarca, Gertrudis, Claudio, etc", "Laurence Olivier", "Dinamarca");
        Obra obra3 = new Obra("La Divina Comedia", "Sala 6", "1:00pm", 139, "Ciacco, San Bernardo, Tomas de Aquino, Porcio Catón, etc", "Manoel de Oliveira", "El mas allá");
        Obra [] arrObras = {obra1, obra2, obra3};
        Console.Clear();
        Console.WriteLine("Bienvenido al sistema de ventas en linea Cine-Teatro\nPor favor ingrese que tipo de usuario es");
        do{
            Console.WriteLine("*****Menu principal*****");
            Console.WriteLine("1.- Dueño\n2.- Usuario\n3.- Salir");
            Console.Write("Ingrese su eleccion: ");
            opcion = Convert.ToInt32(Console.ReadLine());
            switch(opcion){

                case 1:
                    Console.Clear();
                    Console.Write("Por favor ingrese la contraseña para iniciar sesion como dueño\nContraseña: ");
                    contrasenaUsuario = Console.ReadLine();
                    if(contrasenaUsuario.Equals(contrasenaValida)){
                        Console.Clear();
                        if(historialPeliculas.Length > 1){
                            Console.WriteLine("Las ventas en las peliculas son las siguientes:");
                            for (int i = 1; i < historialPeliculas.Length; i++){
                                Console.WriteLine("Venta {0}\nTitulo de funcion: {1}\nHorario: {2}\nBoletos vendidos: {3}\nMonto total de la compra: ${4}\n", i, historialPeliculas[i].getTitulo(), historialPeliculas[i].getHorario(), numeroBoletosPeliculas[i], costoEntradasPeliculas[i]);
                            }
                            Console.WriteLine("");
                        } else {
                            Console.WriteLine("Aun no hay ventas con las peliculas\n");
                            }
                        if(historialObras.Length > 1){
                            Console.WriteLine("Las ventas en obras son las siguientes: ");
                            for (int i = 1; i < historialObras.Length; i++){
                                Console.WriteLine("Venta {0}\nTitulo de funcion: {1}\nHorario: {2}\nBoletos vendidos: {3}\nMonto total de la compra: ${4}\n", i, historialObras[i].getTitulo(), historialObras[i].getHorario(), numeroBoletosObras[i], costoEntradasObras[i]);
                            }
                            Console.WriteLine("");
                        } else {
                            Console.WriteLine("Aun no hay ventas con las obras\n");
                        }
                            Console.WriteLine("Ingrese cualquier tecla para regresar al menu principal...");
                            Console.ReadLine();
                            Console.Clear();
                        } else {
                            Console.WriteLine("La contraseña ingresada es invalida, ingrese cualquier tecla para regresar al menu principal...");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Para continuar por favor ingrese los siguientes datos:");
                    Console.Write("Nombre: ");
                    nombre = Console.ReadLine();
                    Console.Write("Apellido: ");
                    apellido = Console.ReadLine();
                    Console.Write("Direccion: ");
                    direccion = Console.ReadLine();
                    Console.Write("Numero de cuenta Paypal: ");
                    numeroPaypal = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Por favor ingrese que tipo de funcion desea comprar\nPelicula - P/p\nObra - O/o");
                    Console.Write("Ingrese su eleccion: ");
                    funcion = Console.ReadLine();
                    if(funcion.Equals("P") || funcion.Equals("p")){
                        Console.Clear();
                        Pelicula.imprimirPeliculas(arrPeliculas);
                        Console.Write("Ingrese el numero de la pelicula que desea ver: ");
                        pelicula = Convert.ToInt32(Console.ReadLine());
                        if(pelicula >= 1 && pelicula <= 3){
                            Console.Clear();
                            Console.Write("Ingresa la cantidad de boletos que deseas comprar para la pelicula {0}: ", arrPeliculas[pelicula-1].getTitulo());
                            boletos = Convert.ToInt32(Console.ReadLine());
                            if(boletos>0){
                                costoEntradasBoletos = (boletos*arrPeliculas[pelicula-1].getCosto());
                                Console.Write("Haz decidido comprar {0} boletos para la pelicula {1}\nEl pedido tendra un precio de ${2}, deseas confirmar el pedido?\nSi - S/s\nNo - N/n\nIngresa tu opcion: ", boletos, arrPeliculas[pelicula-1].getTitulo(), (arrPeliculas[pelicula-1].getCosto()*boletos));
                                confirmacion = Console.ReadLine();
                                if(confirmacion.Equals("S") || confirmacion.Equals("s")){
                                    Console.Clear();
                                    Console.WriteLine("Se ha completado la compra correctamente\nDatos del pedido\nNombre: {0}\nApellido: {1}\nDireccion: {2}\nNo. de cuenta de Paypal: {3}\nPelicula: {4}\n{5}\nHorario: {6}\n\nIngrese cualquier tecla para regresar al menu principal", nombre, apellido, direccion, numeroPaypal, arrPeliculas[pelicula-1].getTitulo(), arrPeliculas[pelicula-1].getSala(), arrPeliculas[pelicula-1].getHorario());
                                    Console.ReadLine();
                                    Console.Clear();
                                    Pelicula[] peliculaAux = new Pelicula[1];
                                    peliculaAux[0] = arrPeliculas[pelicula-1];
                                    historialPeliculas = historialPeliculas.Concat(peliculaAux).ToArray();
                                    numeroBoletosPeliculas.Add(cantidadComprados, boletos);
                                    costoEntradasPeliculas.Add(cantidadComprados, costoEntradasBoletos);
                                    cantidadComprados++;
                                } else {
                                    Console.WriteLine("Decidiste no confirmar la compra, ingresa cualquier tecla para regresar al menu principal...");
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                            } else {
                                Console.WriteLine("El valor de boletos ingresado es invalido, ingrese cualquier tecla para regresar al menu principal...");
                                Console.ReadLine();
                                Console.Clear();
                            }
                        } else {
                            Console.WriteLine("La pelicula elegida es invalida, ingresa cualquier tecla para regresar al menú principal...");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    } else if(funcion.Equals("O") || funcion.Equals("o")){
                        Console.Clear();
                        Obra.imprimirObras(arrObras);
                        Console.WriteLine("Ingrese el numero de la obra que desea ver:");
                        obra = Convert.ToInt32(Console.ReadLine());
                        if(obra >= 1 && obra <= 3){
                            Console.Clear();
                            Console.Write("Ingresa la cantidad de boletos que deseas comprar para la obra {0}: ", arrObras[obra-1].getTitulo());
                            boletos = Convert.ToInt32(Console.ReadLine());
                            if(boletos>0){
                                costoEntradasBoletos = (boletos*arrObras[obra-1].getCosto());
                                Console.Write("Haz decidido comprar {0} boletos para la obra {1}\nEl pedido tendra un precio de ${2}, deseas confirmar el pedido?\nSi - S/s\nNo - N/n\nIngresa tu opcion: ", boletos, arrObras[obra-1].getTitulo(), (arrObras[obra-1].getCosto()*boletos));
                                confirmacion = Console.ReadLine();
                                if(confirmacion.Equals("S") || confirmacion.Equals("s")){
                                    Console.Clear();
                                    Console.WriteLine("Se ha completado la compra correctamente\nDatos del pedido");
                                    Console.WriteLine("Nombre: {0}\nApellido: {1}\nDireccion: {2}\nNo. de cuenta de Paypal: {3}", nombre, apellido, direccion, numeroPaypal);
                                    Console.WriteLine("Obra: {0}\n{1}\nHorario: {2}\n\nIngrese cualquier tecla para regresar al menu principal...", arrObras[obra-1].getTitulo(), arrObras[obra-1].getSala(), arrObras[obra-1].getHorario());
                                    Console.ReadLine();
                                    Console.Clear();
                                    Obra[] obraAux = new Obra[1];
                                    obraAux[0] = arrObras[obra-1];
                                    historialObras = historialObras.Concat(obraAux).ToArray();
                                    numeroBoletosObras.Add(cantidadComprados2, boletos);
                                    costoEntradasObras.Add(cantidadComprados2, costoEntradasBoletos);
                                    cantidadComprados2++;
                                } else {
                                    Console.WriteLine("Decidiste no confirmar la compra, ingresa cualquier tecla para regresar al menu principal...");
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                            } else {
                                Console.WriteLine("El valor de boletos ingresado es invalido, ingrese cualquier tecla para regresar al menu principal...");
                                Console.ReadLine();
                                Console.Clear();
                            }
                        } else {
                            Console.WriteLine("La obra elegida es invalida, ingresa cualquier tecla para regresar al menú principal...");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    } else {
                        Console.WriteLine("La opcion ingresada es invalida, ingrese cualquier tecla para regresar al menu principal...");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    break;
                case 3:
                    Console.WriteLine("Saliendo del programa...");
                    repetir = 2;
                    break;
                default:
                    Console.WriteLine("Has ingresado una opcion no valida, ingrese cualquier tecla para regresar al menu principal...");
                    Console.ReadLine();
                    Console.Clear();
                    break;
            }
        }while(repetir == 1);
    }
}