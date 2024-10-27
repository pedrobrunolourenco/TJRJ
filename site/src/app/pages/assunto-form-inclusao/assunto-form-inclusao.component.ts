import { Component } from '@angular/core';
import { AssuntoService } from '../../_services/assunto.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { Assunto } from '../../_models/assunto.model';
import { ResultModel } from '../../_models/result.model';

@Component({
  selector: 'app-assunto-form-inclusao',
  templateUrl: './assunto-form-inclusao.component.html',
  styleUrl: './assunto-form-inclusao.component.css'
})
export class AssuntoFormInclusaoComponent {

    constructor(private assuntoService: AssuntoService,
        private toastr: ToastrService,
        private router: Router
    )
    {
    }

    assunto: Assunto = {
      CodigoAssunto: 0,
      Descricao: ''
    };

    gravarAssunto() {
      this.assuntoService.incluirAssunto(this.assunto).subscribe((response: ResultModel) => {
       if(response.sucesso == true){
         this.toastr.success("Assunto gravado com sucesso!" );
         this.router.navigate(['/assunto/list']);
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



}
