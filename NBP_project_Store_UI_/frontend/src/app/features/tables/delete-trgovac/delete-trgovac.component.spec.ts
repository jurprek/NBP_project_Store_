import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteTrgovacComponent } from './delete-trgovac.component';

describe('DeleteTrgovacComponent', () => {
  let component: DeleteTrgovacComponent;
  let fixture: ComponentFixture<DeleteTrgovacComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DeleteTrgovacComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeleteTrgovacComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
