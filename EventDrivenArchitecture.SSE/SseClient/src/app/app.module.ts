import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { SseStreamService } from './sse-stream/sse-stream.service';

import { AppComponent } from './app.component';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [SseStreamService],
  bootstrap: [AppComponent]
})
export class AppModule { }
