using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace appForDatabase.Model
{
    public class Cliente
    {
        public string cpf_cnpj { get; set; }
        public string nome_razao_social { get; set; }
        public string nome_fantasia { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string celular { get; set; }
        public string CEP { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string numero { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string pais { get; set; }
    }

    public partial class Cliente1
    {
        [JsonProperty("cpf_cnpj")]
        public string CpfCnpj { get; set; }

        [JsonProperty("nome_razao_social")]
        public string Nome_razao_social { get; set; }

        [JsonProperty("nome_fantasia")]
        public string Nome_fantasia { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("telefone")]
        public string Telefone { get; set; }

        [JsonProperty("celular")]
        public string Celular { get; set; }

        [JsonProperty("cep")]
        public string Cep { get; set; }

        [JsonProperty("logradouro")]
        public string Logradouro { get; set; }

        [JsonProperty("complemento")]
        public string Complemento { get; set; }

        [JsonProperty("numero")]
        public string Numero { get; set; }

        [JsonProperty("bairro")]
        public string Bairro { get; set; }

        [JsonProperty("cidade")]
        public string Cidade { get; set; }

        [JsonProperty("estado")]
        public string Estado { get; set; }

        [JsonProperty("pais")]
        public string Pais { get; set; }
    }

}
