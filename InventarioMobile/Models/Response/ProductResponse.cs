namespace InventarioMobile.Models.Response
{
    public class ProductResponse
    {
        public Guid ProductId { get; set; }
        public string Descricao { get; set; }
        public int Estoque { get; set; }
        public string Barcode { get; set; }
        public string UnidadeMedida { get; set; }
        public double Preco { get; set; }
        public DateTime AtualizadoEm { get; set; }
    }
}
