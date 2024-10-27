using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TJRJ.Application.Model
{
    public class LivroAutorRetornoModel
    {
        public LivroAutorRetornoModel()
        {
            ListaErros = new List<string>();
        }

        public LivroAutorModel LivroAutor { get; set; }

        [IgnoreDataMember]
        [JsonIgnore]
        public List<string> ListaErros { get; set; }

    }

}
