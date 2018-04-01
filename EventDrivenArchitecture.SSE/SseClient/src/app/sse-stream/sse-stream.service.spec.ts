import { TestBed, inject } from '@angular/core/testing';

import { SseStreamService } from './sse-stream.service';

describe('SseStreamService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SseStreamService]
    });
  });

  it('should be created', inject([SseStreamService], (service: SseStreamService) => {
    expect(service).toBeTruthy();
  }));
});
