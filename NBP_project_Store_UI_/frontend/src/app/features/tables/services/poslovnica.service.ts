import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { HttpParams } from '@angular/common/http';
import { GetPoslovnicaRequest } from '../models/get-poslovnica-request.model';
import { DeletePoslovnicaRequest } from '../models/delete-poslovnica-request.model';

@Injectable({
  providedIn: 'root'
})
export class PoslovnicaService {

  constructor(private http: HttpClient) { }

  addPoslovnica(model: GetPoslovnicaRequest): Observable<GetPoslovnicaRequest> {
    const params = new HttpParams()
                    .set('naziv', model.naziv)
                    .set('poslovnicaID', model.id_Poslovnica);

    return this.http.post<GetPoslovnicaRequest>("https://localhost:44393/api/Poslovnica/Poslovnica", null, { params });
  }

  deletePoslovnica(model: DeletePoslovnicaRequest): Observable<DeletePoslovnicaRequest> {
    return this.http.delete<DeletePoslovnicaRequest>("https://localhost:44393/api/Poslovnica/Poslovnica?id_poslovnica=" + model.id_Poslovnica);
  }

  getAllPoslovnica(): Observable<GetPoslovnicaRequest[]> {
    return this.http.get<GetPoslovnicaRequest[]>("https://localhost:44393/api/Poslovnica/Poslovnica");
  }

  getPoslovnica(model: GetPoslovnicaRequest): Observable<GetPoslovnicaRequest[]> {
    const params = new HttpParams()
                    .set('naziv', model.naziv)
                    .set('id_Poslovnica', model.id_Poslovnica);
    return this.http.get<GetPoslovnicaRequest[]>("https://localhost:44393/api/Poslovnica/Pronađi_Poslovnicu", { params });
  }
}
