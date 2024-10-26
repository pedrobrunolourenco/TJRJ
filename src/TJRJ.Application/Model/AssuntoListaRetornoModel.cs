using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace TJRJ.Application.Model
{
    public class AssuntoListaRetornoModel
    {
        public AssuntoListaRetornoModel()
        {
            ListaErros = new List<string>();
        }

        public IEnumerable<AssuntoModel> Assuntos { get; set; }

        [IgnoreDataMember]
        [JsonIgnore]
        public List<string> ListaErros { get; set; }

    }
}


