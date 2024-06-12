import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPoslovnicaComponent } from './add-poslovnica.component';

describe('AddPoslovnicaComponent', () => {
  let component: AddPoslovnicaComponent;
  let fixture: ComponentFixture<AddPoslovnicaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddPoslovnicaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddPoslovnicaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
