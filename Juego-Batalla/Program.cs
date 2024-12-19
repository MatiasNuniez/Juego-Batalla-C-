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
    public virtual void Atacar()
    {
        if (Puntos > PoderAtaque)
        {
            Puntos -= PoderAtaque;
        }
    }

    public virtual void RecibirAtaque()
    {

    }

}


class Guerrero: Criatura 
{
    public Guerrero(string nombre, int puntos, int poderAtaque) : base(nombre, puntos, poderAtaque) { }


}

class Mago : Criatura
{
    public Mago(string nombre, int puntos, int poderAtaque) : base(nombre, puntos, poderAtaque) { }


}