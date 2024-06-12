import { TestBed } from '@angular/core/testing';

import { PoslovnicaService } from './poslovnica.service';

describe('PoslovnicaService', () => {
  let service: PoslovnicaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PoslovnicaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
