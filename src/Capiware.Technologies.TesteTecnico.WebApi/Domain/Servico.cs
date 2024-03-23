namespace Capiware.Technologies.TesteTecnico.WebApi.Domain;

public class Servico
{
    public Guid Id { get; set; }

    public string Nome { get; set; }

    public StatusEnum Status { get; set; }

    public Decimal Valor { get; set; }

    public DateTime Data { get; set; }

    public Servico() { }

    public Servico(string nome, StatusEnum status, decimal valor, DateTime data)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Status = status;
        Valor = valor;
        Data = data;
    }
}