import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetKupnjaComponent } from './get-kupnja.component';

describe('GetKupnjaComponent', () => {
  let component: GetKupnjaComponent;
  let fixture: ComponentFixture<GetKupnjaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GetKupnjaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetKupnjaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
