using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace TJRJ.Application.Model
{
    public class AutorRetornoModel
    {
        public AutorRetornoModel()
        {
            ListaErros = new List<string>();
        }

        public AutorModel Autor { get; set; }

        [IgnoreDataMember]
        [JsonIgnore]
        public List<string> ListaErros { get; set; }
    }
}


