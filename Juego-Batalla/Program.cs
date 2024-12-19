class Criatura
{
    public string Nombre { get; set; }
    public int Puntos { get; set; }
    public int PoderAtaque {  get; set; }
    public Criatura(string nombre, int puntos, int poderataque)
    {
        this.Nombre = nombre;
        this.Puntos = puntos;
        this.PoderAtaque = poderataque;
    }
    public virtual void Atacar(Criatura enemigo)
    {
        if (Puntos > 0)
        {
            int dano = enemigo.RecibirAtaque(PoderAtaque);
            if (Puntos <= 0)
            {
                Puntos = 0;
                Console.WriteLine(Nombre + "Ha muerto");
            }
            Console.WriteLine(Nombre + "Fue atacado con " + dano + "por: " + enemigo.Nombre);
        }
        else
        {
            Console.Write("No posee los puntos necesarios");
        }
    }

    public virtual int RecibirAtaque(int dano)
    {
        if (Puntos < dano)
        {
            Puntos = 0;

        }
        Puntos -= dano;
        return dano;
    }

}


class Guerrero: Criatura 
{
    public Guerrero(string nombre, int puntos, int poderAtaque, int vida) : base(nombre, puntos, poderAtaque, vida) { }


}

class Mago : Criatura
{
    public Mago(string nombre, int puntos, int poderAtaque, int vida) : base(nombre, puntos, poderAtaque, vida) { }


}