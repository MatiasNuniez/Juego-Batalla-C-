class Criatura
{
    public string Nombre { get; set; }
    public int Puntos { get; set; }
    public int PoderAtaque {  get; set; }
    public int Vida { get; set; }
    public Criatura(string nombre, int puntos, int poderataque, int vida)
    {
        this.Nombre = nombre;
        this.Puntos = puntos;
        this.PoderAtaque = poderataque;
        this.Vida = vida;
    }
    public virtual void Atacar(Criatura enemigo)
    {
        if (Puntos > 0)
        {
            int dano = enemigo.RecibirAtaque(15);
            Console.WriteLine(Nombre + "Fue atacado con " + dano + "por: " + enemigo.Nombre);
        }
    }

    public virtual int RecibirAtaque(int dano)
    {
        Vida = Vida - dano;
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