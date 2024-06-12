import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './core/components/navbar/navbar.component';
import { InventarListComponent } from './features/tables/inventar-list/inventar-list.component';
import { AddInventarComponent } from './features/tables/add-inventar/add-inventar.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { DeleteInventarComponent } from './features/tables/delete-inventar/delete-inventar.component';
import { MatTableModule } from '@angular/material/table';
import { GetInventarComponent } from './features/tables/get-inventar/get-inventar.component';
import { KupacListComponent } from './features/tables/kupac-list/kupac-list.component';
import { AddKupacComponent } from './features/tables/add-kupac/add-kupac.component';
import { DeleteKupacComponent } from './features/tables/delete-kupac/delete-kupac.component';
import { GetKupacComponent } from './features/tables/get-kupac/get-kupac.component';
import { KupnjaListComponent } from './features/tables/kupnja-list/kupnja-list.component';
import { AddKupnjaComponent } from './features/tables/add-kupnja/add-kupnja.component';
import { DatePipe } from '@angular/common';
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

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    InventarListComponent,
    AddInventarComponent,
    DeleteInventarComponent,
    GetInventarComponent,
    KupacListComponent,
    AddKupacComponent,
    DeleteKupacComponent,
    GetKupacComponent,
    KupnjaListComponent,
    AddKupnjaComponent,
    DeleteKupnjaComponent,
    GetKupnjaComponent,
    LaptopListComponent,
    GetLaptopComponent,
    GetLaptopDetailComponent,
    AddLaptopComponent,
    DeleteLaptopComponent,
    PoslovnicaListComponent,
    GetPoslovnicaComponent,
    AddPoslovnicaComponent,
    DeletePoslovnicaComponent,
    PredmetListComponent,
    GetPredmetComponent,
    TrgovacListComponent,
    GetTrgovacComponent,
    AddTrgovacComponent,
    DeleteTrgovacComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    MatTableModule
  ],
  providers: [
    provideClientHydration(),
    DatePipe
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
