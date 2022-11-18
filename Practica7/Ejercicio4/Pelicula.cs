class Pelicula{

    private string titulo;

    private string sala;

    private string horario;

    private double costo;

    public Pelicula(string titulo, string sala, string horario, double costo){
        this.titulo = titulo;
        this.sala = sala;
        this.horario = horario;
        this.costo = costo;
    }

    public void setTitulo(string titulo){
        this.titulo = titulo;
    }

    public string getTitulo(){
        return this.titulo;
    }

    public void setSala(string sala){
        this.sala = sala;
    }

    public string getSala(){
        return this.sala;
    }

    public void setHorario(string horario){
        this.horario = horario;
    }

    public string getHorario(){
        return this.horario;
    }

    public void setCosto(double costo){
        this.costo = costo;
    }

    public double getCosto(){
        return this.costo;
    }

    public static void imprimirPeliculas(Pelicula [] arrPeliculas){
        for (int i = 0; i < arrPeliculas.Length; i++){
            Console.WriteLine("Pelicula número {0}\nTitulo {1}\n{2}\nHorario {3}\nCosto por persona de ${4}\n", i+1, arrPeliculas[i].getTitulo(), arrPeliculas[i].getSala(), arrPeliculas[i].getHorario(), arrPeliculas[i].getCosto());
        }
    }
}