namespace ReservaPassagem.Domain.ValueObjects;

public class Nome
{
    public Nome(string primeiroNome, string ultimoNome)
    {
        PrimeiroNome = primeiroNome;
        this.UltimoNome = UltimoNome;
    }
    
    public string PrimeiroNome { get; private set; }
    public string UltimoNome { get; private set; }
}