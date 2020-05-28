import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-flight-edit',
  templateUrl: './flight-edit.component.html',
  styleUrls: ['./flight-edit.component.scss']
})
export class FlightEditComponent implements OnInit {

  private SERVER_URL = 'https://localhost:5001/newflight';
  private httpOptions ={
    headers: new HttpHeaders({ 
      'Access-Control-Allow-Origin':'*'
    })}; 
    
  public flightEditForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private httpClient: HttpClient)
  {
    
  }

  ngOnInit(): void
  {
    this.flightEditForm = this.formBuilder.group({
      flightNumber:['', Validators.required],
      departureCode:['', Validators.required],
      destinationCode:['', Validators.required],
      departureDate:['', Validators.required],
      returnDate:['', Validators.required]
    });
  }

  public onFormSubmit(): any
  {
    // const formData = new FormData();
    // formData.append('FlightNumber', this.flightEditForm.get('flightNumber').value);
    // formData.append('DepartureCode', this.flightEditForm.get('departureCode').value);
    // formData.append('DestinationCode', this.flightEditForm.get('destinationCode').value);
    // formData.append('DepartureDate', this.flightEditForm.get('departureDate').value);
    // formData.append('ReturnDate', this.flightEditForm.get('returnDate').value);

     var flight : any = {};
     flight.FlightNumber = this.flightEditForm.controls['flightNumber'].value;
     flight.DepartureCode = this.flightEditForm.controls['departureCode'].value;
     flight.DestinationCode = this.flightEditForm.controls['destinationCode'].value;
     flight.DepartureDate = this.flightEditForm.controls['departureDate'].value;
     flight.ReturnDate = this.flightEditForm.controls['returnDate'].value;

    this.httpClient.post<any>(this.SERVER_URL, flight, this.httpOptions).subscribe(
      (res) => console.log(res),
      (err) => console.log(err)
    );
  }
}
