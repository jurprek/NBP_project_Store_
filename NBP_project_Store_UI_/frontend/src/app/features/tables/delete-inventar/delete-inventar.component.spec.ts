import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteInventarComponent } from './delete-inventar.component';

describe('DeleteInventarComponent', () => {
  let component: DeleteInventarComponent;
  let fixture: ComponentFixture<DeleteInventarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DeleteInventarComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeleteInventarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
