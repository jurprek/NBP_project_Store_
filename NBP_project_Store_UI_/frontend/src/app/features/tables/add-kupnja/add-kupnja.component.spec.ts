import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddKupnjaComponent } from './add-kupnja.component';

describe('AddKupnjaComponent', () => {
  let component: AddKupnjaComponent;
  let fixture: ComponentFixture<AddKupnjaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddKupnjaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddKupnjaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
