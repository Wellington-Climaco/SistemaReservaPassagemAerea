namespace ReservaPassagem.Domain.ValueObjects;

public class Origem
{
    public Origem(string cidade,string pais)
    {
        if (string.IsNullOrWhiteSpace(cidade)) 
            throw new ArgumentException("Cidade não pode ser vazio ou nulo.");
        if (string.IsNullOrWhiteSpace(pais))
            throw new ArgumentException("estado não pode ser vazio ou nulo.");
    }
    
    public string Cidade { get; private set; }
    public string Pais { get; private set; }
}