import { Component, OnInit } from '@angular/core';
import { SseStreamService } from './sse-stream/sse-stream.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  title = 'app';
  messages: any = [];

  constructor(private sseStream: SseStreamService) {
  }

  ngOnInit(): void {
    this.sseStream.onMessage().subscribe(message => {
      this.messages.push(message);
    });
  }
}
