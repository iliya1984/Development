import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-customer-edit',
  templateUrl: './customer-edit.component.html',
  styleUrls:['./customer-edit.component.css']  
})
export class CustomerEditComponent implements OnInit {

  public customerEditForm: FormGroup;

  constructor(private router: Router, private formBuilder: FormBuilder) {

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

}
