import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute, Params } from '@angular/router';
import { IFlight } from '../entities/interfaces/IFlight';

@Component({
  selector: 'app-flight-edit',
  templateUrl: './flight-edit.component.html',
  styleUrls: ['./flight-edit.component.scss']
})
export class FlightEditComponent implements OnInit {

  private SERVER_URL = 'https://localhost:5001/api/flights/new';
  private httpOptions ={
    headers: new HttpHeaders({ 
      'Access-Control-Allow-Origin':'*'
    })}; 
    
  public flightEditForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private httpClient: HttpClient, private activatedRoute: ActivatedRoute)
  {
    
  }

  ngOnInit(): void
  {
   

    var flightId = this.activatedRoute.snapshot.params.flightid;

    if(typeof flightId !== 'undefined')
    {
      this.httpClient.get('https://localhost:5001/api/flights/' + flightId).subscribe(
        (data: IFlight[]) => 
        {
          if(Date.length > 0)
          {
            var flight = data[0];
            this.flightEditForm = this.formBuilder.group({
              flightNumber:[flight.flightNumber, Validators.required],
              departureCode:[flight.departureCode, Validators.required],
              destinationCode:[flight.destinationCode, Validators.required],
              departureDate:[flight.departureDate, Validators.required],
              returnDate:[flight.returnDate, Validators.required]
            });
          }
        },
        (err) => console.log(err)
      );
    }
    else
    {
      this.flightEditForm = this.formBuilder.group({
        flightNumber:['', Validators.required],
        departureCode:['', Validators.required],
        destinationCode:['', Validators.required],
        departureDate:['', Validators.required],
        returnDate:['', Validators.required]
      });
    }
  }

  public onFormSubmit(): any
  {
     const flight: any = {};
     flight.FlightNumber = this.flightEditForm.controls['flightNumber'].value;
     flight.DepartureCode = this.flightEditForm.controls['departureCode'].value;
     flight.DestinationCode = this.flightEditForm.controls['destinationCode'].value;
     flight.DepartureDate = this.flightEditForm.controls['departureDate'].value;
     flight.ReturnDate = this.flightEditForm.controls['returnDate'].value;

    this.httpClient.post<any>(this.SERVER_URL, flight, this.httpOptions).subscribe(
      (res) => 
      {
        console.log(res);
      },
      (err) => console.log(err)
    );
  }
}
