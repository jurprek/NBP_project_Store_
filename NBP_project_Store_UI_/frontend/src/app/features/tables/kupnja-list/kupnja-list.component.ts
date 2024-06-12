import { Component, OnDestroy } from '@angular/core';
import { GetKupnjaRequest } from '../models/get-kupnja-request.model';
import { Subscription } from 'rxjs';
import { KupnjaService } from '../services/kupnja.service';

@Component({
  selector: 'app-kupnja-list',
  templateUrl: './kupnja-list.component.html',
  styleUrl: './kupnja-list.component.css'
})

export class KupnjaListComponent implements OnDestroy {

  kupnjaColumns: string[] = ['id_kupnja', 'id_kupac', 'id_predmet', 'id_poslovnica', 'id_trgovac', 'datum_vrijeme'];
  kupnja: GetKupnjaRequest[] = [];

  model: GetKupnjaRequest;
  private getKupnjaSubscription?: Subscription;

  constructor(private kupacServices: KupnjaService) {
    this.model = {
      datum_vrijeme: "",
      id: "",
      id_Kupac: "",
      id_Kupnja: "",
      id_Poslovnica: "",
      id_Predmet: "",
      id_Trgovac: ""
    };
  }

  ngOnInit() {
    this.getKupnjaSubscription = this.kupacServices.getAllKupnja()
    .subscribe({
      next: (response) => {
        console.log("This was seccessful!")
        console.log(response)
        this.kupnja = response;
      }
    })
  }

  ngOnDestroy(): void {
    this.getKupnjaSubscription?.unsubscribe();
  }

}
