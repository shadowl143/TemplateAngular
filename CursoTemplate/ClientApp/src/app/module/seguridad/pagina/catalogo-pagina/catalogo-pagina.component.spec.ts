import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CatalogoPaginaComponent } from './catalogo-pagina.component';

describe('CatalogoPaginaComponent', () => {
  let component: CatalogoPaginaComponent;
  let fixture: ComponentFixture<CatalogoPaginaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CatalogoPaginaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CatalogoPaginaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
