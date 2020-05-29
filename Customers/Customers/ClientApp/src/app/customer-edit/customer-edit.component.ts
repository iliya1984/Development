import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { ICustomer } from '../entities/ICustomer';

@Component({
  selector: 'app-customer-edit',
  templateUrl: './customer-edit.component.html',
  styleUrls:['./customer-edit.component.css']  
})
export class CustomerEditComponent implements OnInit {

  public customerEditForm: FormGroup;

  constructor(private router: Router, private formBuilder: FormBuilder, private httpClient: HttpClient) {

  }

  public ngOnInit(): void
  {
    this.customerEditForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      phone: ['', Validators.required],
      email: ['', Validators.required]
    });
  }

  public onFormSubmit(): void
  {
    var customer: ICustomer =
    {
      id: 0,
      firstName: this.customerEditForm.controls['firstName'].value,
      lastName: this.customerEditForm.controls['lastName'].value,
      email: this.customerEditForm.controls['email'].value,
      phone: this.customerEditForm.controls['phone'].value,
    };

    this.httpClient.post<ICustomer>('api/customers/new', customer)
      .subscribe(
        val => {
          console.log("PUT call successful value returned in body",
            val);

          if (typeof val.id !== 'undefined') {
            alert('New customer was successfully created !');
          }
        },
        response => {
          console.log("PUT call in error", response);
        },
        () => {
          console.log("The PUT observable is now completed.");
        }
      );
  }

}
