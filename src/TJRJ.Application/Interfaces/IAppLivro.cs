﻿using TJRJ.Application.Model;

namespace TJRJ.Application.Interfaces
{
    public interface IAppLivro
    {
        Task<LivroRetornoModel> IncluirLivro(LivroModel livro);

    }
}
