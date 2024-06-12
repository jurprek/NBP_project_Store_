import { Component, OnDestroy } from '@angular/core';
import { GetPoslovnicaRequest } from '../models/get-poslovnica-request.model';
import { Subscription } from 'rxjs';
import { PoslovnicaService } from '../services/poslovnica.service';

@Component({
  selector: 'app-poslovnica-list',
  templateUrl: './poslovnica-list.component.html',
  styleUrl: './poslovnica-list.component.css'
})
export class PoslovnicaListComponent implements OnDestroy{

  poslovnicaColumns: string[] = ['naziv', 'id_Poslovnica'];
  poslovnica: GetPoslovnicaRequest[] = [];

  model: GetPoslovnicaRequest;
  private getPoslovnicaSubscription?: Subscription;

  constructor(private poslovnicaServices: PoslovnicaService) {
    this.model = {
      naziv: "",
      id_Poslovnica: ""
    }
  }

  ngOnInit() {
    this.getPoslovnicaSubscription = this.poslovnicaServices.getAllPoslovnica()
    .subscribe({
      next: (response) => {
        console.log("This was seccessful!")
        console.log(response)
        this.poslovnica = response;
      }
    })
  }

  ngOnDestroy(): void {
    this.getPoslovnicaSubscription?.unsubscribe();
  }

}
