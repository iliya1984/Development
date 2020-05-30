import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatTableDataSource } from '@angular/material/table';
import { ICustomer } from '../entities/ICustomer';
import { MatPaginator } from '@angular/material/paginator';
import { HttpClient } from '@angular/common/http';
import { MatSort } from '@angular/material/sort';

@Component({
  selector: 'app-customer-lookup',
  templateUrl: './customer-lookup.component.html',
  styleUrls:['./customer-lookup.component.css']
})
export class CustomerLookupComponent implements OnInit, AfterViewInit
{
  public displayedColumns: string[] = ['firstName', 'lastName', 'phone', 'email'];
  public dataSource: MatTableDataSource<ICustomer>;

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  constructor(private router: Router, private httpClient: HttpClient)
  {
     
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  public ngOnInit(): void {

    this.httpClient.get('api/customers')
      .subscribe(
        (data: ICustomer[]) => {

          this.dataSource = new MatTableDataSource<ICustomer>(data);
         
          
        },
        response => {
          console.log("PUT call in error", response);
        },
        () => {
          console.log("The PUT observable is now completed.");
        }
      );
  }

  public onNewCustomerButtonClick(event: any): void
  {
    this.router.navigate(['customers/new']);
  }
}
