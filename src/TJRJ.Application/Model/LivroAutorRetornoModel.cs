﻿using System.Runtime.Serialization;
using System.Text.Json.Serialization;

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
