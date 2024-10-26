using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace TJRJ.Application.Model
{
    public class AssuntoRetornoModel
    {
        public AssuntoRetornoModel()
        {
            ListaErros = new List<string>();
        }

        public AssuntoModel Assunto { get; set; }

        [IgnoreDataMember]
        [JsonIgnore]
        public List<string> ListaErros { get; set; }

    }



}
