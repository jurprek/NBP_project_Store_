import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeletePoslovnicaComponent } from './delete-poslovnica.component';

describe('DeletePoslovnicaComponent', () => {
  let component: DeletePoslovnicaComponent;
  let fixture: ComponentFixture<DeletePoslovnicaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DeletePoslovnicaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeletePoslovnicaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
