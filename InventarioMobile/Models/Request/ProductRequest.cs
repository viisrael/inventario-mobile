namespace InventarioMobile.Models.Request;
public class ProductRequest
{
    public Guid ProductId { get; private set; }
    public string Descricao { get; private set; }
    public int Estoque { get; private set; }
    public string Barcode { get; private set; }
    public string UnidadeMedidada { get; private set; }
    public double Preco { get; private set; }
    public DateTime AtualizadoEm { get; private set; }

    public ProductRequest(string descricao, int estoque, string barcode, string unidadeMedidada, double preco, DateTime atualizadoEm)
    {
        ProductId = Guid.NewGuid();
        Descricao = descricao;
        Estoque = estoque;
        Barcode = barcode;
        UnidadeMedidada = unidadeMedidada;
        Preco = preco;
        AtualizadoEm = atualizadoEm;
    }
}
