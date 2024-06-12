import { TestBed } from '@angular/core/testing';

import { KupnjaService } from './kupnja.service';

describe('KupnjaService', () => {
  let service: KupnjaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(KupnjaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
