import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AgregarPaginaComponent } from './agregar-pagina.component';

describe('AgregarPaginaComponent', () => {
  let component: AgregarPaginaComponent;
  let fixture: ComponentFixture<AgregarPaginaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AgregarPaginaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AgregarPaginaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
