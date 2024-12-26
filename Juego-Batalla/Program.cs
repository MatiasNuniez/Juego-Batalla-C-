class Criatura
{
    private string Nombre;
    private int Puntos;
    private int PoderAtaque;

    public Criatura(string nombre, int puntos, int poderAtaque)
    {
        this.Nombre = nombre;
        this.Puntos = puntos;
        this.PoderAtaque = poderAtaque;
    }

    public string GetNombre()
    {
        return Nombre;
    }

    public int GetPuntos()
    {
        return Puntos;
    }

    public int GetPoderAtaque()
    {
        return PoderAtaque;
    }

    
    protected void SetPuntos(int puntos)
    {
        Puntos = Math.Max(0, puntos);
    }

    public void RestarVida(int cantidad)
    {
        SetPuntos(Puntos - cantidad);
        if (Puntos == 0)
        {
            Console.WriteLine(GetNombre() + " ha muerto.");
        }
    }

    public void Curar(int cantidad)
    {
        SetPuntos(Puntos + cantidad > 100 ? 100 : Puntos + cantidad);
    }

    public void Atacar(Criatura enemigo)
    {
        if (GetPuntos() > 0 && enemigo.GetPuntos() > 0)
        {
            enemigo.RestarVida(GetPoderAtaque());
            Console.WriteLine($"{GetNombre()} atacó a {enemigo.GetNombre()}, infligiendo {GetPoderAtaque()} puntos de daño.");
        }
        else
        {
            Console.WriteLine($"El ataque de {GetNombre()} no es posible porque está muerto o {enemigo.GetNombre()} ya está muerto.");
        }
    }

    public virtual void HabilidadEspecial(Criatura enemigo, bool especial)
    {
        Console.WriteLine($"{GetNombre()} no tiene una habilidad especial definida.");
    }
}


class Guerrero : Criatura
{
    public Guerrero(string nombre, int puntos, int poderAtaque)
        : base(nombre, puntos, poderAtaque) { }

    public override void HabilidadEspecial(Criatura enemigo, bool especial)
    {
        if (GetPuntos() <= 0 || enemigo.GetPuntos() <= 0)
        {
            Console.WriteLine($"El ataque especial de {GetNombre()} no es posible porque está muerto o {enemigo.GetNombre()} ya está muerto.");
            return;
        }

        if (especial)
        {
            enemigo.RestarVida(GetPoderAtaque() + 5);
            Console.WriteLine($"{GetNombre()} realizó un ataque brutal a {enemigo.GetNombre()}.");
        }
        else
        {
            Console.WriteLine($"{GetNombre()} falló su ataque especial.");
        }
    }
}

class Mago : Criatura
{
    public Mago(string nombre, int puntos, int poderAtaque)
        : base(nombre, puntos, poderAtaque) { }

    public override void HabilidadEspecial(Criatura enemigo, bool especial)
    {
        if (GetPuntos() <= 0)
        {
            Console.WriteLine($"{GetNombre()} está muerto y no puede realizar una acción.");
            return;
        }

        if (especial)
        {
            enemigo.Curar(10);
            Console.WriteLine($"{GetNombre()} curó a {enemigo.GetNombre()} por 10 puntos. Vida actual: {enemigo.GetPuntos()}.");
        }
        else
        {
            Console.WriteLine($"{GetNombre()} no realizó una acción especial.");
        }
    }
}

class Arquero : Criatura
{
    public Arquero(string nombre, int puntos, int poderAtaque)
        : base(nombre, puntos, poderAtaque) { }

    public override void HabilidadEspecial(Criatura enemigo, bool especial)
    {
        if (GetPuntos() <= 0 || enemigo.GetPuntos() <= 0)
        {
            Console.WriteLine($"El ataque especial de {GetNombre()} no es posible porque está muerto o {enemigo.GetNombre()} ya está muerto.");
            return;
        }

        if (especial)
        {
            for (int i = 0; i < 3; i++)
            {
                Atacar(enemigo);
            }
            Console.WriteLine($"{GetNombre()} disparó una ráfaga de flechas a {enemigo.GetNombre()}.");
        }
    }
}
