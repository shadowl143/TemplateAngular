import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CatalogoMenuComponent } from './catalogo-menu.component';

describe('CatalogoMenuComponent', () => {
  let component: CatalogoMenuComponent;
  let fixture: ComponentFixture<CatalogoMenuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CatalogoMenuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CatalogoMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
