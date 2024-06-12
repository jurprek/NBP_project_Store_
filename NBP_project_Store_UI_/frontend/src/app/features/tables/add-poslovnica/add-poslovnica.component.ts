import { Component, OnDestroy } from '@angular/core';
import { GetPoslovnicaRequest } from '../models/get-poslovnica-request.model';
import { Subscription } from 'rxjs';
import { PoslovnicaService } from '../services/poslovnica.service';

@Component({
  selector: 'app-add-poslovnica',
  templateUrl: './add-poslovnica.component.html',
  styleUrl: './add-poslovnica.component.css'
})
export class AddPoslovnicaComponent implements OnDestroy{

  model: GetPoslovnicaRequest;
  private getPoslovnicaSubscription?: Subscription;

  constructor(private poslovnicaServices: PoslovnicaService) {
    this.model = {
      naziv: "",
      id_Poslovnica: ""
    }
  }

  onFormSubmit() {
    console.log(this.model)
    this.getPoslovnicaSubscription = this.poslovnicaServices.addPoslovnica(this.model)
    .subscribe({
      next: (response) => {
        console.log("This was seccessful!")
        console.log(response)
      }
    })
  }

  ngOnDestroy(): void {
    this.getPoslovnicaSubscription?.unsubscribe();
  }

}
