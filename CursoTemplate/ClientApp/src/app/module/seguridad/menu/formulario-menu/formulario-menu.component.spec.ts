import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormularioMenuComponent } from './formulario-menu.component';

describe('FormularioMenuComponent', () => {
  let component: FormularioMenuComponent;
  let fixture: ComponentFixture<FormularioMenuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormularioMenuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FormularioMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
