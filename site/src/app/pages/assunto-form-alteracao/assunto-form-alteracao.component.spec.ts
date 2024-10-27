import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssuntoFormAlteracaoComponent } from './assunto-form-alteracao.component';

describe('AssuntoFormAlteracaoComponent', () => {
  let component: AssuntoFormAlteracaoComponent;
  let fixture: ComponentFixture<AssuntoFormAlteracaoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AssuntoFormAlteracaoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AssuntoFormAlteracaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
