import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { HttpParams } from '@angular/common/http';
import { GetPredmetRequest } from '../models/get-predmet-request.model';
import { GetKeywordPredmetRequest } from '../models/get-keyword-predmet.model';

@Injectable({
  providedIn: 'root'
})

export class PredmetService {

  constructor(private http: HttpClient) { }

  getAllPredmet(): Observable<GetPredmetRequest[]> {
    return this.http.get<GetPredmetRequest[]>("https://localhost:44393/api/Predmet/Predmet");
  }

  getPredmet(model: GetKeywordPredmetRequest): Observable<GetPredmetRequest[]> {
    const params = new HttpParams()
                    .set('id_predmet', model.searchId)
                    .set('opis', model.searchOpis);
    return this.http.get<GetPredmetRequest[]>("https://localhost:44393/api/Predmet/Pronađi_Predmet", { params });
  }
}
