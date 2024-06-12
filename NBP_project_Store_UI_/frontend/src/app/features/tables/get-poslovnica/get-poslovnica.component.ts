import { Component, OnDestroy } from '@angular/core';
import { GetPoslovnicaRequest } from '../models/get-poslovnica-request.model';
import { Subscription } from 'rxjs';
import { PoslovnicaService } from '../services/poslovnica.service';

@Component({
  selector: 'app-get-poslovnica',
  templateUrl: './get-poslovnica.component.html',
  styleUrl: './get-poslovnica.component.css'
})
export class GetPoslovnicaComponent implements OnDestroy {

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

  onFormSubmit() {
    this.getPoslovnicaSubscription = this.poslovnicaServices.getPoslovnica(this.model)
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
