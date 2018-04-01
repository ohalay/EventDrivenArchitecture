import { Injectable } from '@angular/core';

import { Observable } from 'rxjs/Observable';

@Injectable()
export class SseStreamService {

  private evntSource: EventSource;

  constructor() {
    this.evntSource = new EventSource('http://localhost:47008/sse');
   }

  onMessage(): Observable<any> {
    return Observable.create(observer => {
        this.evntSource.addEventListener('someEvent', (event: MessageEvent) => {
            const obj = JSON.parse(event.data);
            observer.next(obj);
        });
        this.evntSource.onerror = error => {
            observer.error(error);
        };
    });
  }

}
