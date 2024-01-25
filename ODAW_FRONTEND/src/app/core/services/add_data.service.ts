import { Injectable } from '@angular/core';
import { ApiService } from "./api.service";

@Injectable({
  providedIn: 'root'
})
export class AddDataService {
  private readonly route = 'School';
  constructor(private readonly apiService: ApiService) { }

  AddMaterie(materie: any, profesor: any) {
    return this.apiService.post(this.route + '/Creeaza_Materii+Profesori?materie=${materie}', profesor);
  }

  AddProfesor(materie: any, profesor: any) {
    return this.apiService.put(this.route + '/Adauga_Profesor?materie=${materie}', profesor);
  }

  DelProfesor(profesor: any)
  {
    return this.apiService.delete(this.route + '/Sterge_Profesor', profesor);
  }

  DelMaterie(materie: any)
  {
    return this.apiService.delete(this.route + '/Sterge_Materie', materie);
  }
}
