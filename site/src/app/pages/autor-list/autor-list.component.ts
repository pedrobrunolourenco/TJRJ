import { Component } from '@angular/core';
import { AutorService } from '../../_services/autor.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ResultModel } from '../../_models/result.model';
import { Autor } from '../../_models/autor.model';
import * as bootstrap from 'bootstrap';

@Component({
  selector: 'app-autor-list',
  templateUrl: './autor-list.component.html',
  styleUrl: './autor-list.component.css'
})
export class AutorListComponent {

  autorParaExcluir: any;
  autores: any;
  modalInstance: any;

  constructor(
    private autorService: AutorService,
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.autorService.listarAutores().subscribe((response: ResultModel) => {
      if (response.sucesso) {
        this.autores = response.data;
      }
    }, () => {
      this.toastr.error("Erro ao listar autores");
    });
  }

  editarAutor(autor: Autor) {
    this.router.navigate(['/autor/editar', { autor: JSON.stringify(autor) }]);
  }

  setAutorParaExcluir(autor: any) {
    this.autorParaExcluir = autor;
    const modalElement = document.getElementById('confirmDeleteModal');

    if (modalElement) {
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
    this.excluirAutor(this.autorParaExcluir);
    this.fecharModal();
  }

  excluirAutor(autor: any) {
    this.autorService.excluirAutor(autor.autor.codigoAutor).subscribe((response: ResultModel) => {
      if (response.sucesso) {
        this.toastr.success("Autor Excluído com sucesso");
        this.ngOnInit();
      }
    }, () => {
      this.toastr.error("Erro ao excluir autor");
    });
    this.fecharModal();
  }

  private removeBackdrop() {
    document.querySelectorAll('.modal-backdrop').forEach(backdrop => backdrop.remove());
  }

}


