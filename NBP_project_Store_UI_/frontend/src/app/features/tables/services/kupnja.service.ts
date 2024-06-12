import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { HttpParams } from '@angular/common/http';
import { GetKupnjaRequest } from '../models/get-kupnja-request.model';
import { AddKupnjaRequest } from '../models/add-kupnja-request.model';
import { DeleteKupnjaRequest } from '../models/delete-kupnja-request.model';
import { GetKeywordKupnjaRequest } from '../models/get-keyword-kupnja-request.model';

@Injectable({
  providedIn: 'root'
})
export class KupnjaService {

  constructor(private http: HttpClient) { }

  addKupnja(model: AddKupnjaRequest): Observable<AddKupnjaRequest> {
    const params = new HttpParams()
                    .set('id_kupnja', model.id_Kupnja)
                    .set('id_kupac', model.id_Kupac)
                    .set('id_predmet', model.id_Predmet)
                    .set('id_poslovnica', model.id_Poslovnica)
                    .set('id_trgovac', model.id_Trgovac)
                    .set('datum_vrijeme', model.datum_vrijeme);

    return this.http.post<AddKupnjaRequest>("https://localhost:44393/api/Kupnja/Kupnja", null, { params });
  }

  deleteKupnja(model: DeleteKupnjaRequest): Observable<DeleteKupnjaRequest> {
    return this.http.delete<DeleteKupnjaRequest>("https://localhost:44393/api/Kupnja/Kupnja?id_Kupnja=" + model.id_Kupnja);
  }

  getAllKupnja(): Observable<GetKupnjaRequest[]> {
    return this.http.get<GetKupnjaRequest[]>("https://localhost:44393/api/Kupnja/Kupnja");
  }

  getKupnja(model: GetKeywordKupnjaRequest): Observable<GetKupnjaRequest[]> {
    const params = new HttpParams()
                    .set('kupacKeyword', model.kupacKeyword)
                    .set('predmetKeyword', model.predmetKeyword)
                    .set('trgovacKeyword', model.trgovacKeyword);
    return this.http.get<GetKupnjaRequest[]>("https://localhost:44393/api/Kupnja/Pronađi_Kupnju", { params });
  }
}
