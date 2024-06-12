import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetTrgovacComponent } from './get-trgovac.component';

describe('GetTrgovacComponent', () => {
  let component: GetTrgovacComponent;
  let fixture: ComponentFixture<GetTrgovacComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GetTrgovacComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetTrgovacComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
