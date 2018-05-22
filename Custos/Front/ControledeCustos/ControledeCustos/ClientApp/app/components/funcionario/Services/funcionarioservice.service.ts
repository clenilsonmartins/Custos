import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class FuncionarioService {

    myAppUrl: string = "";

    constructor(private _http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.myAppUrl = baseUrl;
    }

    
    getFuncionarios() {
        return this._http.get(this.myAppUrl + 'api/Funcionario/GetFuncionarios')
                .map((response: Response) => response.json())
                .catch(this.errorHandler);
    }

    getFuncionarioById(id: number) {
        return this._http.get(this.myAppUrl + "api/Funcionario/GetFuncionario?pCodigo=" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

    saveFuncionario(Funcionario) {
        return this._http.post(this.myAppUrl + 'api/Funcionario/Post', Funcionario)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

    updateFuncionario(Funcionario) {
        return this._http.put(this.myAppUrl + 'api/Funcionario/Put', Funcionario)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    deleteFuncionario(id: number) {
        return this._http.delete(this.myAppUrl + "api/Funcionario/Delete/?pCodigo=" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    errorHandler(error: Response) {
        console.log(error);
        return Observable.throw(error);
    }
}