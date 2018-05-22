import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { FetchMovimentacaoComponent } from '../fetchmovimentacao/fetchMovimentacao.component';
import { MovimentacaoService } from '../Services/movimentacaoservice.service';


@Component({
    selector: 'createMovimentacao',
    templateUrl: './AddMovimentacao.component.html'
})

export class createMovimentacao implements OnInit {
    MovimentacaoForm: FormGroup;
    title: string = "Create";
    codigo: number = 0;
    errorMessage: any;

    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _MovimentacaoService: MovimentacaoService, private _router: Router) {
        if (this._avRoute.snapshot.params["codigo"]) {
            this.codigo = this._avRoute.snapshot.params["codigo"];
        }

        this.MovimentacaoForm = this._fb.group({
            codigo: [0, [Validators.required]],
            codigoFuncionario: [0, [Validators.required]],
            codigoDepartamento: [0, [Validators.required]],
            dataMovimentacao: ['2018-05-22T00:00:00', [Validators.required]],
            valor: [0, [Validators.required]],
            descricao: ['', [Validators.required]]
        })
    }

    ngOnInit() {
        if (this.codigo > 0) {
            this.title = "Edit";
            this._MovimentacaoService.getMovimentacaoById(this.codigo)
                .subscribe(resp => this.MovimentacaoForm.setValue(resp)
                , error => this.errorMessage = error);
        }
    }

    save() {

        if (!this.MovimentacaoForm.valid) {
            return;
        }

        if (this.title == "Create") {
            this._MovimentacaoService.saveMovimentacao(this.MovimentacaoForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/Post']);
                }, error => this.errorMessage = error)
        }
        else if (this.title == "Edit") {
            this._MovimentacaoService.updateMovimentacao(this.MovimentacaoForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/Put']);
                }, error => this.errorMessage = error) 
        }
    }

    cancel() {
        this._router.navigate(['/GetGetMovimentacaos']);
    }

    get codigoFuncionario() { return this.MovimentacaoForm.get('codigoFuncionario'); }
    get codigoDepartamento() { return this.MovimentacaoForm.get('codigoDepartamento'); }
    get dataMovimentacao() { return this.MovimentacaoForm.get('dataMovimentacao'); }
    get valor() { return this.MovimentacaoForm.get('valor'); }
    get descricao() { return this.MovimentacaoForm.get('descricao'); }

}