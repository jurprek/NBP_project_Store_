import { Component, OnDestroy } from '@angular/core';
import { GetKupacRequest } from '../models/get-kupac-request.model';
import { Subscription } from 'rxjs';
import { KupacService } from '../services/kupac.service';

@Component({
  selector: 'app-get-kupac',
  templateUrl: './get-kupac.component.html',
  styleUrl: './get-kupac.component.css'
})
export class GetKupacComponent implements OnDestroy {

  kupacColumns: string[] = ['id_Kupac', 'ime', 'prezime'];
  kupac: GetKupacRequest[] = [];

  model: GetKupacRequest;
  private getKupacSubscription?: Subscription;

  constructor(private kupacServices: KupacService) {
    this.model = {
      id_Kupac: "",
      ime: "",
      prezime: ""
    };
  }

  onFormSubmit() {
    this.getKupacSubscription = this.kupacServices.getKupac(this.model)
    .subscribe({
      next: (response) => {
        console.log("This was seccessful!")
        console.log(response)
        this.kupac = response;
      },
      error: (response) => {
        this.kupac = [];
      }
    })
  }

  ngOnDestroy(): void {
    this.getKupacSubscription?.unsubscribe();
  }
}
