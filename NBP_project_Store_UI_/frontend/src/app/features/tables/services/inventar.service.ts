import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { HttpParams } from '@angular/common/http';
import { AddInventarRequest } from '../models/add-inventar-request.model';
import { DeleteInventarRequest } from '../models/delete-inventar-request.model';
import { GetInventarRequest } from '../models/get-inventar-request.model';
import { GetKeywordInventarRequest } from '../models/get-keyword-inventar.model';
import { GetKupacRequest } from '../models/get-kupac-request.model';

@Injectable({
  providedIn: 'root'
})

export class InventarService {

  constructor(private http: HttpClient) { }

  addInventar(model: AddInventarRequest): Observable<AddInventarRequest> {
    const params = new HttpParams()
                    .set('id_inventar', model.id_inventar)
                    .set('id_poslovnica', model.id_poslovnica)
                    .set('id_predmet', model.id_predmet)
                    .set('cijena', model.cijena);

    return this.http.post<AddInventarRequest>("https://localhost:44393/api/Inventar/Inventar", null, { params }); //44393
  }

  deleteInventar(model: DeleteInventarRequest): Observable<DeleteInventarRequest> {
    return this.http.delete<DeleteInventarRequest>("https://localhost:44393/api/Inventar/Inventar?id_inventar=" + model.id_inventar);
  }

  getAllInventar(): Observable<GetInventarRequest[]> {
    return this.http.get<GetInventarRequest[]>("https://localhost:44393/api/Inventar/Inventar");
  }

  getInventar(model: GetKeywordInventarRequest): Observable<GetInventarRequest[]> {
    const params = new HttpParams()
                    .set('predmetKeyword', model.predmetKeyword)
                    .set('poslovnicaKeyword', model.poslovnicaKeyword);
    return this.http.get<GetInventarRequest[]>("https://localhost:44393/api/Inventar/Pronađi_u_Inventaru", { params });
  }
}
