import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { OcupadoService } from '../_services/ocupado.service';
import { delay, finalize, Observable } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable()
export class LoadInterceptor implements HttpInterceptor{

  constructor(private ocupadoService: OcupadoService) {

  }

  intercept(req: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    this.ocupadoService.ocupado();
    return next.handle(req).pipe(
      delay(1000),
      finalize(() => {
        this.ocupadoService.desocupado();
      })
    );
  }

};
