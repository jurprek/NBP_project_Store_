import { TestBed } from '@angular/core/testing';

import { TrgovacService } from './trgovac.service';

describe('TrgovacService', () => {
  let service: TrgovacService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TrgovacService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
