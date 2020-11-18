import { Component, OnInit } from '@angular/core';
import { PersonaService } from 'src/app/services/persona.service';
import { persona } from '../../Pulsacion/models/persona';

@Component({
  selector: 'app-persona-registro',
  templateUrl: './persona-registro.component.html',
  styleUrls: ['./persona-registro.component.css']
})
export class PersonaRegistroComponent implements OnInit {
  public persona: persona;
  constructor(private personaService: PersonaService) { }

  ngOnInit(): void {
    this.persona = new persona;
  }
  insertar(){
    this.personaService.post(this.persona).subscribe(p => {
      if (p != null) {
        alert("Se ha guardado. ");
      }
    })
  }
}
