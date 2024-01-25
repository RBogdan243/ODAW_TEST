import {Component} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";
import { AddDataService } from '../../core/services/add_data.service';

@Component({
  selector: 'app-addData',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './AddData.component.html',
  styleUrls: ['./AddData.component.scss'],
})
export class AddDataComponent {
  profesorForm = this.formBuilder.group({
    Id: '',
    Nume: ['', Validators.required],
    Prenume: ['', Validators.required],
    Tip_Profesor: ['', Validators.required],
    Salariu: [Number, Validators.required]
  })

  materieForm = new FormGroup({
    Id: new FormControl(''),
    Nume: new FormControl('', Validators.required),
    Descriere: new FormControl('', Validators.required)
  })

  constructor(private readonly formBuilder: FormBuilder, private readonly addDataService: AddDataService) {

  }

  message: any;

  CreateMat()
  {
    console.log(this.profesorForm.value);
    console.log(this.materieForm.value);
    this.message = null;
    if (this.profesorForm.valid && this.materieForm.valid) {
      this.addDataService.AddMaterie(this.materieForm, this.profesorForm).subscribe(
        data => {
          this.message = String(data.message);
        },
        error => {
          this.message = String(error);
        });
    }
  }

  CreateProf()
  {
    console.log(this.profesorForm.value);
    console.log(this.materieForm.value);
    this.message = null;
    if (this.profesorForm.valid && this.materieForm.valid) {
      this.addDataService.AddProfesor(this.materieForm, this.profesorForm).subscribe(
        data => {
          this.message = String(data.message);
        },
        error => {
          this.message = String(error);
        });
    }
  }

  DeleteProf()
  {
    console.log(this.profesorForm.value);
    this.message = null;
    if (this.profesorForm.valid)
    {
      this.addDataService.DelProfesor(this.profesorForm).subscribe(
        data => {
          this.message = String(data.message);
        },
        error => {
          this.message = String(error);
        });
    }
  }

  DeleteMat() {
    console.log(this.materieForm.value);
    this.message = null;
    if (this.materieForm.valid) {
      this.addDataService.DelProfesor(this.materieForm).subscribe(
        data => {
          this.message = String(data.message);
        },
        error => {
          this.message = String(error);
        });
    }
  }
}
