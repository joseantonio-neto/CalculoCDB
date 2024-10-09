import { TestBed } from '@angular/core/testing';

import { CalculateCdbService } from './calculate-cdb.service';

describe('CalculateCdbService', () => {
  let service: CalculateCdbService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CalculateCdbService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
