import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InventarListComponent } from './features/tables/inventar-list/inventar-list.component';
import { AddInventarComponent } from './features/tables/add-inventar/add-inventar.component';
import { DeleteInventarComponent } from './features/tables/delete-inventar/delete-inventar.component';
import { GetInventarComponent } from './features/tables/get-inventar/get-inventar.component';
import { KupacListComponent } from './features/tables/kupac-list/kupac-list.component';
import { AddKupacComponent } from './features/tables/add-kupac/add-kupac.component';
import { DeleteKupacComponent } from './features/tables/delete-kupac/delete-kupac.component';
import { GetKupacComponent } from './features/tables/get-kupac/get-kupac.component';
import { KupnjaListComponent } from './features/tables/kupnja-list/kupnja-list.component';
import { AddKupnjaComponent } from './features/tables/add-kupnja/add-kupnja.component';
import { DeleteKupnjaComponent } from './features/tables/delete-kupnja/delete-kupnja.component';
import { GetKupnjaComponent } from './features/tables/get-kupnja/get-kupnja.component';
import { LaptopListComponent } from './features/tables/laptop-list/laptop-list.component';
import { GetLaptopComponent } from './features/tables/get-laptop/get-laptop.component';
import { GetLaptopDetailComponent } from './features/tables/get-laptop-detail/get-laptop-detail.component';
import { AddLaptopComponent } from './features/tables/add-laptop/add-laptop.component';
import { DeleteLaptopComponent } from './features/tables/delete-laptop/delete-laptop.component';
import { PoslovnicaListComponent } from './features/tables/poslovnica-list/poslovnica-list.component';
import { GetPoslovnicaComponent } from './features/tables/get-poslovnica/get-poslovnica.component';
import { AddPoslovnicaComponent } from './features/tables/add-poslovnica/add-poslovnica.component';
import { DeletePoslovnicaComponent } from './features/tables/delete-poslovnica/delete-poslovnica.component';
import { PredmetListComponent } from './features/tables/predmet-list/predmet-list.component';
import { GetPredmetComponent } from './features/tables/get-predmet/get-predmet.component';
import { TrgovacListComponent } from './features/tables/trgovac-list/trgovac-list.component';
import { GetTrgovacComponent } from './features/tables/get-trgovac/get-trgovac.component';
import { AddTrgovacComponent } from './features/tables/add-trgovac/add-trgovac.component';
import { DeleteTrgovacComponent } from './features/tables/delete-trgovac/delete-trgovac.component';

const routes: Routes = [
  {
    path: "tablice/inventar",
    component: InventarListComponent
  },
  {
    path: "tablice/inventar/get",
    component: GetInventarComponent
  },
  {
    path: "tablice/inventar/add",
    component: AddInventarComponent
  },
  {
    path: "tablice/inventar/delete",
    component: DeleteInventarComponent
  },
  {
    path:"tablice/kupac",
    component: KupacListComponent
  },
  {
    path: "tablice/kupac/add",
    component: AddKupacComponent
  },
  {
    path: "tablice/kupac/delete",
    component: DeleteKupacComponent
  },
  {
    path: "tablice/kupac/get",
    component: GetKupacComponent
  },
  {
    path: "tablice/kupnja",
    component: KupnjaListComponent
  },
  {
    path: "tablice/kupnja/add",
    component: AddKupnjaComponent
  },
  {
    path: "tablice/kupnja/delete",
    component: DeleteKupnjaComponent
  },
  {
    path: "tablice/kupnja/get",
    component: GetKupnjaComponent
  },
  {
    path: "tablice/laptop",
    component: LaptopListComponent
  },
  {
    path: "tablice/laptop/get",
    component: GetLaptopComponent
  },
  {
    path: "tablice/laptop/get/detail",
    component: GetLaptopDetailComponent
  },
  {
    path: "tablice/laptop/add",
    component: AddLaptopComponent
  },
  {
    path: "tablice/laptop/delete",
    component: DeleteLaptopComponent
  },
  {
    path: "tablice/poslovnica",
    component: PoslovnicaListComponent
  },
  {
    path: "tablice/poslovnica/get",
    component: GetPoslovnicaComponent
  },
  {
    path: "tablice/poslovnica/add",
    component: AddPoslovnicaComponent
  },
  {
    path: "tablice/poslovnica/delete",
    component: DeletePoslovnicaComponent
  },
  {
    path: "tablice/predmet",
    component: PredmetListComponent
  },
  {
    path: "tablice/predmet/get",
    component: GetPredmetComponent
  },
  {
    path: "tablice/trgovac",
    component: TrgovacListComponent
  },
  {
    path: "tablice/trgovac/get",
    component: GetTrgovacComponent
  },
  {
    path: "tablice/trgovac/add",
    component: AddTrgovacComponent
  },
  {
    path: "tablice/trgovac/delete",
    component: DeleteTrgovacComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
