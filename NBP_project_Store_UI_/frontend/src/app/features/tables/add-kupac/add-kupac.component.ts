import { Component, OnDestroy } from '@angular/core';
import { GetKupacRequest } from '../models/get-kupac-request.model';
import { Subscription } from 'rxjs';
import { KupacService } from '../services/kupac.service';

@Component({
  selector: 'app-add-kupac',
  templateUrl: './add-kupac.component.html',
  styleUrl: './add-kupac.component.css'
})
export class AddKupacComponent implements OnDestroy {

  model: GetKupacRequest;
  private addKupacSubscription?: Subscription;

  constructor(private kupacServices: KupacService) {
    this.model = {
      id_Kupac: "",
      ime: "",
      prezime: ""
    };
  }

  onFormSubmit() {
    console.log(this.model);
    this.addKupacSubscription = this.kupacServices.addKupac(this.model)
    .subscribe({
      next: (response) => {
        console.log("This was seccessful!")
      }
    })
  }

  ngOnDestroy(): void {
    this.addKupacSubscription?.unsubscribe();

  }
}

