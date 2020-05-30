import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
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

  constructor(private router: Router, private activatedRoute: ActivatedRoute, private formBuilder: FormBuilder, private httpClient: HttpClient) {

  }

  public ngOnInit(): void
  {
    var customerId = this.activatedRoute.snapshot.params.id;

    if (typeof customerId !== 'undefined') {

      this.httpClient.get<ICustomer[]>('api/customers?customerId=' + customerId)
        .subscribe(
          (customers: ICustomer[]) => {

            if (customers.length > 0)
            {
              this.customerEditForm = this.formBuilder.group({
                firstName: [customers[0].firstName, Validators.required],
                lastName: [customers[0].lastName, Validators.required],
                phone: [customers[0].email, Validators.required],
                email: [customers[0].phone, Validators.required]
              });
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
    else
    {
      this.customerEditForm = this.formBuilder.group({
        firstName: ['', Validators.required],
        lastName: ['', Validators.required],
        phone: ['', Validators.required],
        email: ['', Validators.required]
      });
    }
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
