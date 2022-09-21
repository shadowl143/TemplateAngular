import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormularioPaginaComponent } from './formulario-pagina.component';

describe('FormularioPaginaComponent', () => {
  let component: FormularioPaginaComponent;
  let fixture: ComponentFixture<FormularioPaginaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormularioPaginaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FormularioPaginaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
