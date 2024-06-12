import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { HttpParams } from '@angular/common/http';
import { GetKupacRequest } from '../models/get-kupac-request.model';
import { DeleteKupacRequest } from '../models/delete-kupac-request.model';

@Injectable({
  providedIn: 'root'
})
export class KupacService {

  constructor(private http: HttpClient) { }

  addKupac(model: GetKupacRequest): Observable<GetKupacRequest> {
    const params = new HttpParams()
                    .set('id_kupac', model.id_Kupac)
                    .set('ime', model.ime)
                    .set('prezime', model.prezime);

    return this.http.post<GetKupacRequest>("https://localhost:44393/api/Kupac/Kupac", null, { params });
  }

  deleteKupac(model: DeleteKupacRequest): Observable<DeleteKupacRequest> {
    return this.http.delete<DeleteKupacRequest>("https://localhost:44393/api/Kupac/Kupac?id_Kupac=" + model.id_Kupac);
  }

  getAllKupac(): Observable<GetKupacRequest[]> {
    return this.http.get<GetKupacRequest[]>("https://localhost:44393/api/Kupac/Kupac");
  }

  getKupac(model: GetKupacRequest): Observable<GetKupacRequest[]> {
    const params = new HttpParams()
                                .set('id_kupac', model.id_Kupac)
                                .set('ime', model.ime)
                                .set('prezime', model.prezime);
    return this.http.get<GetKupacRequest[]>("https://localhost:44393/api/Kupac/Pronađi_Kupca", { params });
  }

}
