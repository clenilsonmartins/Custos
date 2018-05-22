import { Component, Inject } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { DepartamentoService } from '../Services/departamentoservice.service'
//components / funcionario / services / funcionarioservice.service

@Component({
    selector: 'fetchDepartamento',
    templateUrl: './fetchDepartamento.component.html'
})

export class FetchDepartamentoComponent {
    public DepList: DepData[];

    constructor(public http: Http, private _router: Router, private _DepartamentoService: DepartamentoService) {
        this.getFuncionarios();
    }

    getFuncionarios() {
        this._DepartamentoService.getDepartamentos().subscribe(
            data => this.DepList = data
        )
    }

    delete(funcionarioID) {
        var ans = confirm("Você Quer Realmente Excluir o Departamento com o Código: " + funcionarioID);
        if (ans) {
            this._DepartamentoService.deleteDepartamento(funcionarioID).subscribe((data) => {
                this.getFuncionarios();
            }, error => console.error(error)) 
        }
    }
}

interface DepData {
    codigo: number;
    nome: string;
}