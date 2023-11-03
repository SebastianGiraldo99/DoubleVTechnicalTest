import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IClientDTO } from 'src/Enums/ClientDTO';
import { IproductsDTO } from 'src/Enums/ProductsDTO';
import { IFacturaModel } from 'src/Enums/FacturaModelDTO';
import { IFacturaRespuestaDTO } from 'src/Enums/FacturaRespuestaDTO';

@Injectable({
    providedIn: 'root'
  })

export class FacturacionService {
  private baseUrl: string = 'https://api.example.com'; 

  base_url: string ;
  constructor(private http: HttpClient,  @Inject('BASE_URL') baseUrl: string) {
    this.base_url = baseUrl + 'weatherforecast';
  }

  
  getClients(): Observable<IClientDTO[]> {
    const url = `${this.base_url}/GetClientes`; 
    return this.http.get<IClientDTO[]>(url);
  }

  getProducts(): Observable<IproductsDTO[]>{
    const url = `${this.base_url}/GetProducts`; 
    return this.http.get<IproductsDTO[]>(url);
  }

  getFactura(client : number, bill: number): Observable<IFacturaRespuestaDTO[]>{
     const params = new HttpParams()
     .set('client', client.toString())
     .set('bill', bill.toString());
   return this.http.get<IFacturaRespuestaDTO[]>(`${this.base_url}/GetFactura`, { params });
  }

  
  saveFactura(data: IFacturaModel): Observable<any> {
    const url = `${this.base_url}/SaveFactura`; 
    return this.http.post(url, data);
  }
}