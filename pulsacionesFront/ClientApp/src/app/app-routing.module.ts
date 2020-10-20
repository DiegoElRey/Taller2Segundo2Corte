import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { PersonaRegistroComponent } from './Pulsacion/persona-registro/persona-registro.component';
import { PersonaConsultaComponent } from './Pulsacion/persona-consulta/persona-consulta.component';

const routes: Routes =[
  {
    path: "Registro",
    component: PersonaRegistroComponent
  },
  {
    path: "Consulta",
    component: PersonaConsultaComponent
  }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
