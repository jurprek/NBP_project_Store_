import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetKupacComponent } from './get-kupac.component';

describe('GetKupacComponent', () => {
  let component: GetKupacComponent;
  let fixture: ComponentFixture<GetKupacComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GetKupacComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetKupacComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
