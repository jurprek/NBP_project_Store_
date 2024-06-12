import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KupacListComponent } from './kupac-list.component';

describe('KupacListComponent', () => {
  let component: KupacListComponent;
  let fixture: ComponentFixture<KupacListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [KupacListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(KupacListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
