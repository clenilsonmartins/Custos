import { Component, Inject } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { MovimentacaoService } from '../Services/movimentacaoservice.service'


@Component({
    selector: 'fetchMovimentacao',
    templateUrl: './fetchMovimentacao.component.html'
})

export class FetchMovimentacaoComponent {
    public MovList: Movimentcao[];

    constructor(public http: Http, private _router: Router, private _MovimentacaoService: MovimentacaoService) {
        this.getFuncionarios();
    }

    getFuncionarios() {
        this._MovimentacaoService.getMovimentacaos().subscribe(
            data => this.MovList = data
        )
    }

    delete(MovimentacaoID) {
        var ans = confirm("Você Quer Realmente Excluir a Movimentacao com o Código: " + MovimentacaoID);
        if (ans) {
            this._MovimentacaoService.deleteMovimentacao(MovimentacaoID).subscribe((data) => {
                this.getFuncionarios();
            }, error => console.error(error)) 
        }
    }
}

export interface Funcionario {
    codigo: number;
    nome: string;
    email: string;
    departamentos?: any;
}

export interface Funcionario2 {
    codigo: number;
    nome: string;
    email: string;
    departamentos?: any;
}

export interface Departamento {
    codigo: number;
    nome: string;
    funcionario: Funcionario2;
}

export interface Movimentcao {
    codigo: number;
    codigoFuncionario: number;
    codigoDepartamento: number;
    dataMovimentacao: Date;
    valor: number;
    descricao: string;
    funcionario: Funcionario;
    departamento: Departamento;
}
