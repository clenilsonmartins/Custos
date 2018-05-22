import { Component, Inject } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { FuncionarioService } from '../Services/funcionarioservice.service'
//components / funcionario / services / funcionarioservice.service

@Component({
    selector: 'fetchFuncionario',
    templateUrl: './fetchFuncionario.component.html'
})

export class FetchFuncionarioComponent {
    public funList: FuncionarioData[];

    constructor(public http: Http, private _router: Router, private _FuncionarioService: FuncionarioService) {
        this.getFuncionarios();
    }

    getFuncionarios() {
        this._FuncionarioService.getFuncionarios().subscribe(
            data => this.funList = data
        )
    }

    delete(funcionarioID) {
        var ans = confirm("Você Quer Realmente Excluir o Funcionário com o Código: " + funcionarioID);
        if (ans) {
            this._FuncionarioService.deleteFuncionario(funcionarioID).subscribe((data) => {
                this.getFuncionarios();
            }, error => console.error(error)) 
        }
    }
}

interface FuncionarioData {
    codigo: number;
    nome: string;
    email: string;    
}