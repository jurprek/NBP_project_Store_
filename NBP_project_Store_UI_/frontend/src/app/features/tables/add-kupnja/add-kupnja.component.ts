import { Component, OnDestroy } from '@angular/core';
import { AddKupnjaRequest } from '../models/add-kupnja-request.model';
import { Subscription } from 'rxjs';
import { KupnjaService } from '../services/kupnja.service';
import { DatePipe } from '@angular/common';


@Component({
  selector: 'app-add-kupnja',
  templateUrl: './add-kupnja.component.html',
  styleUrl: './add-kupnja.component.css'
})
export class AddKupnjaComponent implements OnDestroy{

  model: AddKupnjaRequest;
  private addKupnjaSubscription?: Subscription;

  constructor(private kupnjaServices: KupnjaService,  private datePipe: DatePipe) {
    this.model = {
      datum_vrijeme: String(datePipe.transform(new Date(), 'yyyy-MM-dd HH:mm:ss')), //"2024-06-09 21:57:31.233",
      id_Kupac: "",
      id_Kupnja: "",
      id_Poslovnica: "",
      id_Predmet: "",
      id_Trgovac: ""
    };
  }

  onFormSubmit() {
    console.log(this.model);
    this.addKupnjaSubscription = this.kupnjaServices.addKupnja(this.model)
    .subscribe({
      next: (response) => {
        console.log("This was seccessful!")
      }
    })
  }

  ngOnDestroy(): void {
    this.addKupnjaSubscription?.unsubscribe();
  }

}
