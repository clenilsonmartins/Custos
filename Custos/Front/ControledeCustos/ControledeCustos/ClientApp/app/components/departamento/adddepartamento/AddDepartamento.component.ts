import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { FetchDepartamentoComponent } from '../fetchdepartamento/fetchDepartamento.component';    
import { DepartamentoService } from '../Services/departamentoservice.service';


@Component({
    selector: 'createDepartamento',
    templateUrl: './AddDepartamento.component.html'
})

export class createDepartamento implements OnInit {
    DepartamentoForm: FormGroup;
    title: string = "Create";
    codigo: number = 0;
    errorMessage: any;

    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _DepartamentoService: DepartamentoService, private _router: Router) {
        if (this._avRoute.snapshot.params["codigo"]) {
            this.codigo = this._avRoute.snapshot.params["codigo"];
        }

        this.DepartamentoForm = this._fb.group({
            codigo: [0, [Validators.required]],
            nome: ['', [Validators.required]]
        })
    }

    ngOnInit() {
        if (this.codigo > 0) {
            this.title = "Edit";
            this._DepartamentoService.getDepartamentoById(this.codigo)
                .subscribe(resp => this.DepartamentoForm.setValue(resp)
                , error => this.errorMessage = error);
        }
    }

    save() {

        if (!this.DepartamentoForm.valid) {
            return;
        }

        if (this.title == "Create") {
            this._DepartamentoService.saveDepartamento(this.DepartamentoForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/Post']);
                }, error => this.errorMessage = error)
        }
        else if (this.title == "Edit") {
            this._DepartamentoService.updateDepartamento(this.DepartamentoForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/Put']);
                }, error => this.errorMessage = error) 
        }
    }

    cancel() {
        this._router.navigate(['/GetDepartamentos']);
    }

    get nome() { return this.DepartamentoForm.get('nome'); }

}