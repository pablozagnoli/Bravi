import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DetalhesContatoComponent } from './pages/detalhes-contato/detalhes-contato.component';
import { NavbarComponent } from './components/navbar/navbar.component';

import {MatTableModule} from '@angular/material/table';
import { TablePessoasComponent } from './components/tablePessoas/tablePessoas.component';
import { HomeComponent } from './pages/home/home.component';
import { EditarContatoComponent } from './pages/editar-contato/editar-contato.component';

@NgModule({
  declarations: [
    AppComponent,
    DetalhesContatoComponent,
    NavbarComponent,
    TablePessoasComponent,
    HomeComponent,
    EditarContatoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatTableModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
