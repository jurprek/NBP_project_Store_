import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PoslovnicaListComponent } from './poslovnica-list.component';

describe('PoslovnicaListComponent', () => {
  let component: PoslovnicaListComponent;
  let fixture: ComponentFixture<PoslovnicaListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PoslovnicaListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PoslovnicaListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
