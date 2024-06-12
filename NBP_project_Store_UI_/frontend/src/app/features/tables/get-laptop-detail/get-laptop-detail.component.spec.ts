import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetLaptopDetailComponent } from './get-laptop-detail.component';

describe('GetLaptopDetailComponent', () => {
  let component: GetLaptopDetailComponent;
  let fixture: ComponentFixture<GetLaptopDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GetLaptopDetailComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetLaptopDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
