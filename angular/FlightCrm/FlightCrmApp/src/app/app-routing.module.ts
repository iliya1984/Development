import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FlightsComponent } from './flights/flights.component';
import { FlightEditComponent } from './flight-edit/flight-edit.component';


const routes: Routes = [
  {
    path: '',
    component: FlightsComponent
  },
  {
    path: 'flights',
    component: FlightsComponent
  },
  {
    path: 'flights/new',
    component: FlightEditComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
