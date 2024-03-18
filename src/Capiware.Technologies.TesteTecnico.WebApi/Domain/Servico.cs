namespace Capiware.Technologies.TesteTecnico.WebApi.Domain;
    
public class Servico  
{
    public Guid Id { get; set; }

    public string Nome { get; set; }

    public StatusEnum Status { get; set; }

    public Decimal Valor { get; set; }

    public DateTime Data { get; set; }
}