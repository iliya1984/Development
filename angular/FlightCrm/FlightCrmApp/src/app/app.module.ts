import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FlightsComponent } from './flights/flights.component';
import { FlightEditComponent } from './flight-edit/flight-edit.component';

@NgModule({
  declarations: [
    AppComponent,
    FlightsComponent,
    FlightEditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
