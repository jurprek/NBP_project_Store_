import { Component, OnDestroy } from '@angular/core';
import { GetKupnjaRequest } from '../models/get-kupnja-request.model';
import { GetKeywordKupnjaRequest } from '../models/get-keyword-kupnja-request.model';
import { Subscription } from 'rxjs';
import { KupnjaService } from '../services/kupnja.service';

@Component({
  selector: 'app-get-kupnja',
  templateUrl: './get-kupnja.component.html',
  styleUrl: './get-kupnja.component.css'
})
export class GetKupnjaComponent implements OnDestroy {

  kupnjaColumns: string[] = ['id_kupnja', 'id_kupac', 'id_predmet', 'id_poslovnica', 'id_trgovac', 'datum_vrijeme'];
  kupnja: GetKupnjaRequest[] = [];

  model: GetKeywordKupnjaRequest;
  private getKupnjaSubscription?: Subscription;

  constructor(private kupnjaServices: KupnjaService) {
    this.model = {
      kupacKeyword: "",
      predmetKeyword: "",
      trgovacKeyword: ""
    };
  }

  onFormSubmit() {
    console.log(this.model)
    this.kupnja = [];
    this.getKupnjaSubscription = this.kupnjaServices.getKupnja(this.model)
    .subscribe({
      next: (response) => {
        console.log("This was seccessful!")
        console.log(response)
        this.kupnja = response;
      },
      error: (response) => {
        this.kupnja = [];
      }
    })
  }

  ngOnDestroy(): void {
    this.getKupnjaSubscription?.unsubscribe();
  }

}
