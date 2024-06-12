import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetPoslovnicaComponent } from './get-poslovnica.component';

describe('GetPoslovnicaComponent', () => {
  let component: GetPoslovnicaComponent;
  let fixture: ComponentFixture<GetPoslovnicaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GetPoslovnicaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetPoslovnicaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
