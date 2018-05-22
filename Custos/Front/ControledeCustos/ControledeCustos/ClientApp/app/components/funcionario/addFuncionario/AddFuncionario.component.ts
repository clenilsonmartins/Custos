import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { FetchFuncionarioComponent } from '../fetchFuncionario/fetchFuncionario.component';    
import { FuncionarioService } from '../Services/funcionarioservice.service';


@Component({
    selector: 'createFuncionario',
    templateUrl: './AddFuncionario.component.html'
})

export class createFuncionario implements OnInit {
    FuncionarioForm: FormGroup;
    title: string = "Create";
    codigo: number = 0;
    errorMessage: any;

    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _FuncionarioService: FuncionarioService, private _router: Router) {
        if (this._avRoute.snapshot.params["codigo"]) {
            this.codigo = this._avRoute.snapshot.params["codigo"];
        }

        this.FuncionarioForm = this._fb.group({
            codigo: [0, [Validators.required]],
            nome: ['', [Validators.required]],
            email: ['', [Validators.required]]
        })
    }

    ngOnInit() {
        if (this.codigo > 0) {
            this.title = "Edit";
            this._FuncionarioService.getFuncionarioById(this.codigo)
                .subscribe(resp => this.FuncionarioForm.setValue(resp)
                , error => this.errorMessage = error);
        }
    }

    save() {

        if (!this.FuncionarioForm.valid) {
            return;
        }

        if (this.title == "Create") {
            this._FuncionarioService.saveFuncionario(this.FuncionarioForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/Post']);
                }, error => this.errorMessage = error)
        }
        else if (this.title == "Edit") {
            this._FuncionarioService.updateFuncionario(this.FuncionarioForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/Put']);
                }, error => this.errorMessage = error) 
        }
    }

    cancel() {
        this._router.navigate(['/GetFuncionarios']);
    }

    get nome() { return this.FuncionarioForm.get('nome'); }
    get email() { return this.FuncionarioForm.get('email'); }
}