import { TestBed } from '@angular/core/testing';

import { PlatformServices } from './platform-services';

describe('PlatformServices', () => {
  let service: PlatformServices;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PlatformServices);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
