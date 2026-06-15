import { TestBed } from '@angular/core/testing';

import { CatalogueServices } from './catalogue-services';

describe('CatalogueServices', () => {
  let service: CatalogueServices;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CatalogueServices);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
