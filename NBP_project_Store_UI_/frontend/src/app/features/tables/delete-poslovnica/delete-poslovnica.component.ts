import { Component, OnDestroy } from '@angular/core';
import { DeletePoslovnicaRequest } from '../models/delete-poslovnica-request.model';
import { Subscription } from 'rxjs';
import { PoslovnicaService } from '../services/poslovnica.service';
import { unsubscribe } from 'diagnostics_channel';

@Component({
  selector: 'app-delete-poslovnica',
  templateUrl: './delete-poslovnica.component.html',
  styleUrl: './delete-poslovnica.component.css'
})
export class DeletePoslovnicaComponent implements OnDestroy{

  model: DeletePoslovnicaRequest;
  private deletePoslovnicaSubscription?: Subscription;

  constructor(private poslovnicaServices: PoslovnicaService) {
    this.model = {
      id_Poslovnica: ""
    }
  }

  onFormSubmit() {
    this.deletePoslovnicaSubscription = this.poslovnicaServices.deletePoslovnica(this.model)
    .subscribe({
      next: (response) => {
        console.log("This was seccessful!")
        console.log(response)
      }
    })
  }

  ngOnDestroy(): void {
    this.deletePoslovnicaSubscription?.unsubscribe();
  }

}
