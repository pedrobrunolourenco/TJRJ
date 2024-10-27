import { Component, OnInit } from '@angular/core';
import { AssuntoService } from '../../_services/assunto.service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';
import { Assunto } from '../../_models/assunto.model';
import { ResultModel } from '../../_models/result.model';

@Component({
  selector: 'app-assunto-form-alteracao',
  templateUrl: './assunto-form-alteracao.component.html',
  styleUrl: './assunto-form-alteracao.component.css'
})
export class AssuntoFormAlteracaoComponent implements OnInit {

  constructor(private assuntoService: AssuntoService,
    private toastr: ToastrService,
    private router: Router,
    private route: ActivatedRoute
)
{
}

  assunto: Assunto = {
    CodigoAssunto: 0,
    Descricao: ''
  };

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const assuntoParam = params.get('assunto');
      if (assuntoParam) {
        var json = JSON.parse(assuntoParam);
        this.assunto.CodigoAssunto = json.assunto.codigoAssunto;
        this.assunto.Descricao = json.assunto.descricao;
      }
    });
  }

gravarAssunto() {
  this.assuntoService.alterarAssunto(this.assunto).subscribe((response: ResultModel) => {
   if(response.sucesso == true){
     this.toastr.success("Assunto alterado com sucesso!" );
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
