class Obra: Pelicula{

    private string actores;

    private string director;

    private string escenario;

    public Obra(string titulo, string sala, string horario, double costo, string actores, string director, string escenario): base(titulo, sala, horario, costo){
        this.actores = actores;
        this.director = director;
        this.escenario = escenario;
    }

    public void setActores(string actores){
        this.actores = actores;
    }

    public string getActores(){
        return this.actores;
    }

    public void setDirector(string director){
        this.director = director;
    }

    public string getDirector(){
        return this.director;
    }

    public void setEscenario(string escenario){
        this.escenario = escenario;
    }

    public string getEscenario(){
        return this.escenario;
    }

    public static void imprimirObras(Obra [] arrObras){
        for (int i = 0; i < arrObras.Length; i++){
            Console.WriteLine("Obra número {0}\nTitulo {1}\n{2}\nHorario {3}\nActores {4}\nDirector {5}\nEscenario en {6}\nCosto por persona de ${7}\n", i+1, arrObras[i].getTitulo(), arrObras[i].getSala(), arrObras[i].getHorario(), arrObras[i].getActores(), arrObras[i].getDirector(), arrObras[i].getEscenario(), arrObras[i].getCosto());
        }
    }
}