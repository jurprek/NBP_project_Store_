import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetInventarComponent } from './get-inventar.component';

describe('GetInventarComponent', () => {
  let component: GetInventarComponent;
  let fixture: ComponentFixture<GetInventarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GetInventarComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetInventarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
