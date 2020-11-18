import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { persona } from '../Pulsacion/models/persona';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';

@Injectable({
  providedIn: 'root'
})
export class PersonaService {
  baseUrl: string;​
  constructor(
    private http: HttpClient,​
      @Inject('BASE_URL') baseUrl: string,​
      private handleErrorService: HandleHttpErrorService)​
   { 
    this.baseUrl = baseUrl;
   }

   get(): Observable<persona[]> {​
    return this.http.get<persona[]>(this.baseUrl + 'api/PersonaPulsacion')​.pipe(​
            tap(_ => this.handleErrorService.log('datos enviados')),​
            catchError(this.handleErrorService.handleError<persona[]>('Consulta Persona', null))​
        );​
  }​

  post(persona: persona): Observable<persona> {​
    return this.http.post<persona>(this.baseUrl + 'api/PersonaPulsacion', persona)​.pipe(​
            tap(_ => this.handleErrorService.log('datos enviados')),​
            catchError(this.handleErrorService.handleError<persona>('Registrar Persona', null))​
        );​
}
}
