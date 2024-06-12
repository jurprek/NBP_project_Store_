import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { HttpParams } from '@angular/common/http';
import { AddTrgovacRequest } from '../models/add-trgovac-request.model';
import { DeleteTrgovacRequest } from '../models/delete-trgovac-request.model';
import { GetTrgovacRequest } from '../models/get-trgovac-request.model';
import { GetKeywordTrgovacRequest } from '../models/get-keyword-trgovac.model';

@Injectable({
  providedIn: 'root'
})

export class TrgovacService {

  constructor(private http: HttpClient) { }

  addTrgovac(model: AddTrgovacRequest): Observable<AddTrgovacRequest> {
    const params = new HttpParams()
                    .set('ime', model.ime_Trgovac)
                    .set('prezime', model.prezime_Trgovac)
                    .set('id_trgovac', model.id_Trgovac);

    return this.http.post<AddTrgovacRequest>("https://localhost:44393/api/Trgovac/Trgovac", null, { params });
  }

  deleteTrgovac(model: DeleteTrgovacRequest): Observable<DeleteTrgovacRequest> {
    return this.http.delete<DeleteTrgovacRequest>("https://localhost:44393/api/Trgovac/Trgovac?id_Trgovac=" + model.id_Trgovac);
  }

  getAllTrgovac(): Observable<GetTrgovacRequest[]> {
    return this.http.get<GetTrgovacRequest[]>("https://localhost:44393/api/Trgovac/Trgovac");
  }

  getTrgovac(model: GetKeywordTrgovacRequest): Observable<GetTrgovacRequest[]> {
    const params = new HttpParams()
                    .set('id_Trgovac', model.searchId)
                    .set('ime', model.searchIme)
                    .set('prezime', model.searchPrezime);
    return this.http.get<GetTrgovacRequest[]>("https://localhost:44393/api/Trgovac/Pronađi_Trgovca", { params });
  }
}
