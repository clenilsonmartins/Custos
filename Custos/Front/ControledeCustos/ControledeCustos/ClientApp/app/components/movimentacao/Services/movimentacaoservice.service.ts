import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class MovimentacaoService {

    myAppUrl: string = "";

    constructor(private _http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.myAppUrl = baseUrl;
    }

    
    getMovimentacaos() {
        return this._http.get(this.myAppUrl + 'api/Movimentacao/GetMovimentacaos')
                .map((response: Response) => response.json())
                .catch(this.errorHandler);
    }

    getMovimentacaoById(id: number) {
        return this._http.get(this.myAppUrl + "api/Movimentacao/GetMovimentacao?pCodigo=" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

    saveMovimentacao(Movimentacao) {
        return this._http.post(this.myAppUrl + 'api/Movimentacao/Post', Movimentacao)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

    updateMovimentacao(Movimentacao) {
        return this._http.put(this.myAppUrl + 'api/Movimentacao/Put', Movimentacao)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    deleteMovimentacao(id: number) {
        return this._http.delete(this.myAppUrl + "api/Movimentacao/Delete/?pCodigo=" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    errorHandler(error: Response) {
        console.log(error);
        return Observable.throw(error);
    }
}