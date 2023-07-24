import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-tablePessoas',
  templateUrl: './tablePessoas.component.html',
  styleUrls: ['./tablePessoas.component.css']
})
export class TablePessoasComponent implements OnInit {

  constructor(private router: Router) { }

  displayedColumns: string[] = ['position', 'name', 'weight', 'symbol'];
  dataSource = ELEMENT_DATA;

  ngOnInit() {
  }

  clickedRow(row: any) {
    this.router.navigate(['detalheslocacao'], {
      queryParams: {
        numorca: row.nomecliente,
      },
    });
  }

}

export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {position: 2, name: 'Augusto', weight: 4.0026, symbol: 'He'},
  {position: 1, name: 'Larissa', weight: 1.0079, symbol: 'H'},
  {position: 3, name: 'Pedro', weight: 6.941, symbol: 'Li'},
  {position: 4, name: 'Pablo', weight: 9.0122, symbol: 'Be'},
  {position: 5, name: 'Duda', weight: 10.811, symbol: 'B'},
];
