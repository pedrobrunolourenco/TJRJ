import { Component } from '@angular/core';
import { LivroService } from '../../_services/livro.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { Livro } from '../../_models/livro.model';
import { ResultModel } from '../../_models/result.model';

@Component({
  selector: 'app-livro-form-inclusao',
  templateUrl: './livro-form-inclusao.component.html',
  styleUrl: './livro-form-inclusao.component.css'
})
export class LivroFormInclusaoComponent {


    constructor(private livroService: LivroService,
      private toastr: ToastrService,
      private router: Router
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

      gravarLivro() {
        this.livroService.incluirLivro(this.livro).subscribe((response: ResultModel) => {
        if(response.sucesso == true){
          this.toastr.success("Livro gravado com sucesso!" );
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




