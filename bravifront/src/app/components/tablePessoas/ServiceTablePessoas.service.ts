import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ServiceTablePessoasService {

constructor(private httpcliente: HttpClient) { }


GetPessoas(parans: any): Observable<any> {
  return this.httpcliente.post<any>("https://localhost:5000/pessoas/gettodos", parans);
}

}
