import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { HttpParams } from '@angular/common/http';
import { GetLaptopRequest } from '../models/get-laptop-request.model';
import { GetOneLaptopRequest } from '../models/get-one-laptop-request.model';
import { GetLaptopDetailsRequest } from '../models/get-laptop-details-request.model';

@Injectable({
  providedIn: 'root'
})
export class LaptopService {

  constructor(private http: HttpClient) { }

  addLaptop(model: GetLaptopRequest): Observable<GetLaptopRequest> {
    const headers = {
      'Content-Type':'application/json'
    };
  
    return this.http.post<GetLaptopRequest>("https://localhost:44393/api/Laptop/Laptop", model);
  }

  deleteLaptop(model: GetOneLaptopRequest): Observable<GetOneLaptopRequest> {
    return this.http.delete<GetOneLaptopRequest>("https://localhost:44393/api/Laptop/Laptop?id_Laptop=" + model.id_Laptop);
  }

  getAllLaptops(): Observable<GetLaptopRequest[]> {
    return this.http.get<GetLaptopRequest[]>("https://localhost:44393/api/Laptop");
  }

  getLaptop(model: GetOneLaptopRequest): Observable<GetLaptopRequest[]> {
    const params = new HttpParams()
                    .set('id_laptop', model.id_Laptop);
    return this.http.get<GetLaptopRequest[]>("https://localhost:44393/api/Laptop/Pronađi_Laptop", { params });
  }

  getLaptopDetails(model: GetLaptopDetailsRequest): Observable<GetLaptopRequest[]> {
    const params = new HttpParams()
                    .set('keyword', model.keyword);
    return this.http.get<GetLaptopRequest[]>("https://localhost:44393/api/Laptop/Detaljna_Pretraga", { params });
  }
}
