import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import {MatSort} from '@angular/material/sort';
import {MatTableDataSource} from '@angular/material/table';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { IFlight } from '../entities/interfaces/IFlight';

export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {position: 1, name: 'Hydrogen', weight: 1.0079, symbol: 'H'},
  {position: 2, name: 'Helium', weight: 4.0026, symbol: 'He'},
  {position: 3, name: 'Lithium', weight: 6.941, symbol: 'Li'},
  {position: 4, name: 'Beryllium', weight: 9.0122, symbol: 'Be'},
  {position: 5, name: 'Boron', weight: 10.811, symbol: 'B'},
  {position: 6, name: 'Carbon', weight: 12.0107, symbol: 'C'},
  {position: 7, name: 'Nitrogen', weight: 14.0067, symbol: 'N'},
  {position: 8, name: 'Oxygen', weight: 15.9994, symbol: 'O'},
  {position: 9, name: 'Fluorine', weight: 18.9984, symbol: 'F'},
  {position: 10, name: 'Neon', weight: 20.1797, symbol: 'Ne'},
];

@Component({
  selector: 'app-flights',
  templateUrl: './flights.component.html',
  styleUrls: ['./flights.component.scss']
})
export class FlightsComponent implements OnInit {

  public dataSource: MatTableDataSource<IFlight>;
  public displayedColumns: string[] = ['flightNumber', 'departureCode', 'destinationCode', 'departureDate', 'returnDate', 'actions'];

  
  private SERVER_URL = 'https://localhost:5001/api/flights';
  private httpOptions ={
    headers: new HttpHeaders({ 
      'Access-Control-Allow-Origin':'*'
    })}; 
  

  @ViewChild(MatSort, {static: true}) sort: MatSort;


  constructor(private router: Router, private httpClient: HttpClient) { }

  ngOnInit(): void
  {
    this.httpClient.get(this.SERVER_URL, {}).subscribe(
      (data: IFlight[]) => 
      {
        this.dataSource = new MatTableDataSource(data);
        this.dataSource.sort = this.sort;
      },
      (err) => console.log(err)
    );
  }

  public onNewFlightButtonClick()
  {
    this.router.navigate(['flights/new']);
  }

  public onFlightEditButtonClick(element: any)
  {
    this.router.navigate(['flights/edit', element.id.toString()]);
  }
}
