import { Component, OnDestroy } from '@angular/core';
import { GetKeywordInventarRequest } from '../models/get-keyword-inventar.model';
import { InventarService } from '../services/inventar.service';
import { response } from 'express';
import { Subscription } from 'rxjs';
import { GetInventarRequest } from '../models/get-inventar-request.model';
import { GetKupacRequest } from '../models/get-kupac-request.model';
import { KupacService } from '../services/kupac.service';

@Component({
  selector: 'app-kupac-list',
  templateUrl: './kupac-list.component.html',
  styleUrl: './kupac-list.component.css'
})
export class KupacListComponent implements OnDestroy {


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

  ngOnInit() {
    this.getKupacSubscription = this.kupacServices.getAllKupac()
    .subscribe({
      next: (response) => {
        console.log("This was seccessful!")
        console.log(response)
        this.kupac = response;
      }
    })
  }

  ngOnDestroy(): void {
    this.getKupacSubscription?.unsubscribe();

  }
}
