import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllFacturasComponent } from './all-facturas.component';

describe('AllFacturasComponent', () => {
  let component: AllFacturasComponent;
  let fixture: ComponentFixture<AllFacturasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AllFacturasComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AllFacturasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
