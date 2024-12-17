using Flunt.Validations;
using InventarioMobile.Models.Request;

namespace InventarioMobile.Contratos
{
    public class ProductContract : Contract<ProductRequest>
    {
        public ProductContract(ProductRequest request)
        {
            Requires()
                .IsNotEmpty(request.ProductId, nameof(request.ProductId), "Id do produto é obrigatório");

            Requires()
                .IsNotNullOrEmpty(request.Descricao, nameof(request.Descricao), "Descrição não pode ser vazia");

            Requires()
                .IsGreaterThan(request.Estoque, -1, nameof(request.Estoque), "Estoque não pode ser negativo");

            Requires()
                .IsNotNullOrEmpty(request.Barcode, nameof(request.Barcode), "Código de barras não pode ser vazio");

            Requires()
                .IsNotNullOrEmpty(request.UnidadeMedida, nameof(request.UnidadeMedida), "Unidade de medida não pode ser vazia");

            Requires()
                .IsGreaterThan(request.Preco, 0, nameof(request.Preco), "Preço deve ser mais do que 0");
        }
    }
}
