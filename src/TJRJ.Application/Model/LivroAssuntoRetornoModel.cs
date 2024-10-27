using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace TJRJ.Application.Model
{
    public class LivroAssuntoRetornoModel
    {
        public LivroAssuntoRetornoModel()
        {
            ListaErros = new List<string>();
        }

        public LivroAssuntoModel LivroAssunto { get; set; }

        [IgnoreDataMember]
        [JsonIgnore]
        public List<string> ListaErros { get; set; }
    }
}
