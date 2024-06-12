import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetPredmetComponent } from './get-predmet.component';

describe('GetPredmetComponent', () => {
  let component: GetPredmetComponent;
  let fixture: ComponentFixture<GetPredmetComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GetPredmetComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetPredmetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
