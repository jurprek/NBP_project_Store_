import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InventarListComponent } from './inventar-list.component';

describe('InventarListComponent', () => {
  let component: InventarListComponent;
  let fixture: ComponentFixture<InventarListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [InventarListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InventarListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
