using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace TJRJ.Application.Model
{
    public class LivroRetornoModel
    {
        public LivroRetornoModel()
        {
            ListaErros = new List<string>();
        }

        public LivroModel Livro { get; set; }

        [IgnoreDataMember]
        [JsonIgnore]
        public List<string> ListaErros { get; set; }

    }
}
