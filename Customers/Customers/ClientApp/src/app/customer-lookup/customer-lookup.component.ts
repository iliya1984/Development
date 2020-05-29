import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-customer-lookup',
  templateUrl: './customer-lookup.component.html',
})
export class CustomerLookupComponent
{
  constructor(private router: Router)
  {
     
  }

  public onNewCustomerButtonClick(event: any): void
  {
    this.router.navigate(['customers/new']);
  }
}
