import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddKupacComponent } from './add-kupac.component';

describe('AddKupacComponent', () => {
  let component: AddKupacComponent;
  let fixture: ComponentFixture<AddKupacComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddKupacComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddKupacComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
