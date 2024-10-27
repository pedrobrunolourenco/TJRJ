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
      console.log(livroParam);
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


}
