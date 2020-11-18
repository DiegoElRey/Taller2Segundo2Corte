import { Component, OnInit } from '@angular/core';
import { PersonaService } from 'src/app/services/persona.service';

@Component({
  selector: 'app-persona-consulta',
  templateUrl: './persona-consulta.component.html',
  styleUrls: ['./persona-consulta.component.css']
})
export class PersonaConsultaComponent implements OnInit {
  public personas: any = [];
  constructor(private personaService: PersonaService) { }

  ngOnInit(): void {
    this.get();
  }
  get(){
    this.personaService.get().subscribe(result => {
      this.personas = result;
    })
  }

}
