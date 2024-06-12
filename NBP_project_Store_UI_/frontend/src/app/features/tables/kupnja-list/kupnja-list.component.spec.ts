import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KupnjaListComponent } from './kupnja-list.component';

describe('KupnjaListComponent', () => {
  let component: KupnjaListComponent;
  let fixture: ComponentFixture<KupnjaListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [KupnjaListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(KupnjaListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
