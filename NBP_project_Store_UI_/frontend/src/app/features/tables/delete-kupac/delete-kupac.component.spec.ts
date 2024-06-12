import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteKupacComponent } from './delete-kupac.component';

describe('DeleteKupacComponent', () => {
  let component: DeleteKupacComponent;
  let fixture: ComponentFixture<DeleteKupacComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DeleteKupacComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeleteKupacComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
