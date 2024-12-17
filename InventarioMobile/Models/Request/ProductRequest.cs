namespace InventarioMobile.Models.Request
{
    public class ProductRequest
    {
        public ProductRequest
            (
                string descricao, 
                int estoque, 
                string barcode, 
                string unidadeMedida, 
                double preco, 
                DateTime atualizadoEm)
        {
            ProductId = Guid.NewGuid();
            Descricao = descricao;
            Estoque = estoque;
            Barcode = barcode;
            UnidadeMedida = unidadeMedida;
            Preco = preco;
            AtualizadoEm = atualizadoEm;
        }

        public ProductRequest
            (
                Guid productId,
                string descricao,
                int estoque,
                string barcode,
                double? preco
            )
        {
            ProductId = productId;
            Descricao = descricao;
            Estoque = estoque;
            Barcode = barcode;
            Preco = preco ?? 0;
            UnidadeMedida = "Unidade";
            AtualizadoEm = DateTime.Now;
        }

        public Guid ProductId { get; private set; }
        public string Descricao { get; private set; }
        public int Estoque { get; private set; }
        public string Barcode { get; private set; }
        public string UnidadeMedida { get; private set; }
        public double Preco { get; private set; }
        public DateTime AtualizadoEm { get; private set; }

    }
}
