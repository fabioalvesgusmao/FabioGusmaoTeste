using System;

namespace FabioGusmao.DataMock.Entities
{
    public class StockOrderJson
    {
        public int? Id { get; set; }
        public DateTime? DateTime { get; set; }
        public string TipoOperacao { get; set; }
        public string Ativo { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public int? Conta { get; set; }
    }
}
