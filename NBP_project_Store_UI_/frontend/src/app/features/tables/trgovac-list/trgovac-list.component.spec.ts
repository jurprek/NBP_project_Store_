import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TrgovacListComponent } from './trgovac-list.component';

describe('TrgovacListComponent', () => {
  let component: TrgovacListComponent;
  let fixture: ComponentFixture<TrgovacListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TrgovacListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TrgovacListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
