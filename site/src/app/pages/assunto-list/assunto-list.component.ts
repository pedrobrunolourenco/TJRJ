import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AssuntoService } from '../../_services/assunto.service';
import { ResultModel } from '../../_models/result.model';
import { Router } from '@angular/router';
import { Assunto } from '../../_models/assunto.model';
import * as bootstrap from 'bootstrap';

@Component({
  selector: 'app-assunto-list',
  templateUrl: './assunto-list.component.html',
  styleUrls: ['./assunto-list.component.css']
})
export class AssuntoListComponent implements OnInit {

  assuntoParaExcluir: any;
  assuntos: any;
  modalInstance: any;

  constructor(
    private assuntoService: AssuntoService,
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.assuntoService.listarAssuntos().subscribe((response: ResultModel) => {
      if (response.sucesso) {
        this.assuntos = response.data;
      }
    }, () => {
      this.toastr.error("Erro ao listar Perfis");
    });
  }

  editarAssunto(assunto: Assunto) {
    this.assuntoService.assunto = assunto;
    this.router.navigate(['/assunto/editar', { assunto: JSON.stringify(assunto) }]);
  }

  setAssuntoParaExcluir(assunto: any) {
    this.assuntoParaExcluir = assunto;
    const modalElement = document.getElementById('confirmDeleteModal');

    if (modalElement) {  // Verifica se o modalElement existe
      this.modalInstance = new bootstrap.Modal(modalElement, { backdrop: 'static' });
      this.modalInstance.show();

      modalElement.addEventListener('hidden.bs.modal', () => {
        this.removeBackdrop();
      });
    } else {
      console.error("Modal element 'confirmDeleteModal' not found.");
    }
  }

  fecharModal() {
    if (this.modalInstance) {
      this.modalInstance.hide();
    }
  }

  confirmarExclusao() {
    this.excluirAssunto(this.assuntoParaExcluir);
    this.fecharModal();
  }

  excluirAssunto(assunto: any) {
    this.assuntoService.excluirAssunto(assunto.assunto.codigoAssunto).subscribe((response: ResultModel) => {
      if (response.sucesso) {
        this.toastr.success("Assunto Excluído com sucesso");
        this.ngOnInit();
      }
    }, () => {
      this.toastr.error("Erro ao excluir assunto");
    });
    this.fecharModal();
  }

  private removeBackdrop() {
    document.querySelectorAll('.modal-backdrop').forEach(backdrop => backdrop.remove());
  }
}
