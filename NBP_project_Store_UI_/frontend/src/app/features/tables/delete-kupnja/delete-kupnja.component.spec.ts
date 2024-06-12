import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteKupnjaComponent } from './delete-kupnja.component';

describe('DeleteKupnjaComponent', () => {
  let component: DeleteKupnjaComponent;
  let fixture: ComponentFixture<DeleteKupnjaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DeleteKupnjaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeleteKupnjaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
