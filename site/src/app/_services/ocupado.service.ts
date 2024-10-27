import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root'
})
export class OcupadoService {

  requestCount = 0;

  constructor(private spnner: NgxSpinnerService) { }

  ocupado(){
    this.requestCount++;
    this.spnner.show(undefined, {type: 'ball-spin-fade'});

  }

  desocupado(){
    this.requestCount--;
    if(this.requestCount <= 0) this.requestCount = 0
    this.spnner.hide();
  }
}
