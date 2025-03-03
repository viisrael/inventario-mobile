using Flunt.Validations;
using InventarioMobile.Models.Request;

namespace InventarioMobile.Contracts
{
    public class ProductContract: Contract<ProductRequest>
    {
        public ProductContract(ProductRequest request)
        {
            Requires()
                .IsNotEmpty(request.ProductId, nameof(request.ProductId), "Id do produto é obrigatório");

            Requires()
                .IsNotNullOrEmpty(request.Descricao, nameof(request.Descricao), "Descrição do produto é obrigatório");

            Requires()
                .IsGreaterThan(request.Estoque, -1, nameof(request.Estoque), "Estoque não pode ser negativo");

            Requires()
                .IsNotNullOrEmpty(request.Barcode, nameof(request.Barcode), "Código de barras não pode ser vazio");

            Requires()
                .IsNotNullOrEmpty(request.UnidadeMedida, nameof(request.UnidadeMedida),
                    "Informe uma unidade de medida");

            Requires()
                .IsGreaterThan(request.Preco, 0, nameof(request.Preco), "Preço deve ser maior que 0");

        }
    }
}
