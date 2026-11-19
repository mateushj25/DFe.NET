using System.Xml.Serialization;

namespace NFe.Classes.Servicos.Evento
{
    /// <summary>
    ///     P24 - Dados do pagamento do evento 110300 - Vinculação Pagamento (NT 2026.006)
    /// </summary>
    public class gPgtoEvento
    {
        /// <summary>
        ///     P25 - Identificador da transação financeira, de acordo com a transação de pagamento (2 a 35 caracteres)
        /// </summary>
        [XmlAttribute("idTransacao")]
        public string idTransacao { get; set; }

        /// <summary>
        ///     P26 - Código do meio de pagamento, 2 dígitos (ver IT DFe 2026.001)
        /// </summary>
        [XmlElement("tpMeioPgto")]
        public string tpMeioPgto { get; set; }

        /// <summary>
        ///     P27 - CNPJ completo do recebedor do pagamento (fornecedor, plataforma ou outra entidade que receba o pagamento do adquirente)
        /// </summary>
        [XmlElement("CNPJReceb")]
        public string CNPJReceb { get; set; }

        /// <summary>
        ///     P28 - CNPJ base da instituição financeira ou de pagamento utilizada pelo recebedor
        /// </summary>
        [XmlElement("CNPJBasePSP")]
        public string CNPJBasePSP { get; set; }
    }
}