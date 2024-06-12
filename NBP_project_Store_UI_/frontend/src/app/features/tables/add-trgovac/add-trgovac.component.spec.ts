import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddTrgovacComponent } from './add-trgovac.component';

describe('AddTrgovacComponent', () => {
  let component: AddTrgovacComponent;
  let fixture: ComponentFixture<AddTrgovacComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddTrgovacComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddTrgovacComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
