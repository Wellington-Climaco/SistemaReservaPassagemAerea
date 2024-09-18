namespace ReservaPassagem.Domain.ValueObjects;

public class Destino
{
    public Destino(string cidade, string pais)
    {
        Cidade = cidade;
        Pais = pais;
    }

    public string Cidade { get; private set; }
    public string Pais { get; private set; }
}