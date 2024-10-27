import { Component } from '@angular/core';
import { LivroService } from '../../_services/livro.service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';
import { Livro } from '../../_models/livro.model';
import { ResultModel } from '../../_models/result.model';

@Component({
  selector: 'app-livro-form-alteracao',
  templateUrl: './livro-form-alteracao.component.html',
  styleUrl: './livro-form-alteracao.component.css'
})
export class LivroFormAlteracaoComponent {

  constructor(private livroService: LivroService,
    private toastr: ToastrService,
    private router: Router,
    private route: ActivatedRoute
  )
  {
  }

  lassuntos = false;
  lautores = false;

  autores: any;
  assuntos: any;

  livro: Livro = {
    CodI: 0,
    Titulo: '',
    Editora: '',
    Edicao: 1,
    AnoPublicacao: ''
  };

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const livroParam = params.get('livro');
      if (livroParam) {
        var json = JSON.parse(livroParam);
        this.livro.CodI = json.codigoLivro;
        this.livro.Titulo = json.titulo;
        this.livro.Editora = json.editora;
        this.livro.Edicao = json.edicao;
        this.livro.AnoPublicacao = json.anoPublicacao;
      }
    });
  }

  gravarLivro() {
    this.livroService.alterarLivro(this.livro).subscribe((response: ResultModel) => {
    if(response.sucesso == true){
      this.toastr.success("Livro alterado com sucesso!" );
      this.router.navigate(['/livro/list']);
    }
    if(response.sucesso == false){
      response.mensagens.forEach(mensagem => {
        this.toastr.error(mensagem);
      });
    }
    }, (erro) => {
      this.toastr.error("Erro ao gravar livro");
    });
  }

  setAssuntos(livro: Livro) {
    this.livroService.listarAssuntos(livro.CodI).subscribe((response: ResultModel) => {
        this.assuntos = response.data;
        this.lassuntos = true;
        this.lautores = false;
    }, () => {
      this.toastr.error("Erro ao listar assuntos");
    });
  }

  setAutores(livro: Livro) {
    this.livroService.listarAutores(livro.CodI).subscribe((response: ResultModel) => {
      this.autores = response.data;
      this.lassuntos = false;
      this.lautores = true;
    }, () => {
      this.toastr.error("Erro ao listar autores");
    });
  }

  setVoltar() {
    this.lassuntos = false;
    this.lautores = false;
  }

  incluirAssunto(assunto: any) {
    var request = {
      Livro_CodI: this.livro.CodI,
      Assunto_CodAs: assunto.codAs
    }


    this.livroService.incluirAssunto(request).subscribe((response: ResultModel) => {
      if(response.sucesso == true){
        this.toastr.success("Assunto incluído com sucesso" );
        this.setAssuntos(this.livro);
      }
      if(response.sucesso == false){
        response.mensagens.forEach(mensagem => {
          this.toastr.error(mensagem);
        });
      }
      }, (erro) => {
        this.toastr.error("Erro ao gravar assunto");
      });
  }

  excluirAssunto(assunto: any) {
    console.log(assunto)
  }

  incluirAutor(autor: any) {
    var request = {
      Livro_CodI: this.livro.CodI,
      Autor_CodAu: autor.codAu
    }

    this.livroService.incluirAutor(request).subscribe((response: ResultModel) => {
      if(response.sucesso == true){
        this.toastr.success("Autor incluído com sucesso" );
        this.setAutores(this.livro);
      }
      if(response.sucesso == false){
        response.mensagens.forEach(mensagem => {
          this.toastr.error(mensagem);
        });
      }
      }, (erro) => {
        this.toastr.error("Erro ao gravar autor");
      });
    }

  excluirAutor(autor: any) {
    console.log(autor)
  }


}
