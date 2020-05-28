import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-flight-edit',
  templateUrl: './flight-edit.component.html',
  styleUrls: ['./flight-edit.component.scss']
})
export class FlightEditComponent implements OnInit {

  public flightEditForm: FormGroup;

  constructor(private formBuilder: FormBuilder)
  {
    
  }

  ngOnInit(): void 
  {
    this.flightEditForm = this.formBuilder.group({
      flightNumber:[Validators.required],
      departureCode:[Validators.required],
      destinationCode:[Validators.required],
      departureDate:[Validators.required],
      returnDate:[Validators.required]
    });
  }

  public onFormSubmit(): any
  {

  }
}
