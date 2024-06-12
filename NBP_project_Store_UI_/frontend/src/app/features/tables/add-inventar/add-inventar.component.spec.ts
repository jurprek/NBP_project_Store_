import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddInventarComponent } from './add-inventar.component';

describe('AddInventarComponent', () => {
  let component: AddInventarComponent;
  let fixture: ComponentFixture<AddInventarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddInventarComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddInventarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
