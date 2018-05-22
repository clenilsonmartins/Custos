import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class DepartamentoService {

    myAppUrl: string = "";

    constructor(private _http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.myAppUrl = baseUrl;
    }

    
    getDepartamentos() {
        return this._http.get(this.myAppUrl + 'api/Departamento/GetDepartamentos')
                .map((response: Response) => response.json())
                .catch(this.errorHandler);
    }

    getDepartamentoById(id: number) {
        return this._http.get(this.myAppUrl + "api/Departamento/GetDepartamento?pCodigo=" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

    saveDepartamento(Departamento) {
        return this._http.post(this.myAppUrl + 'api/Departamento/Post', Departamento)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

    updateDepartamento(Departamento) {
        return this._http.put(this.myAppUrl + 'api/Departamento/Put', Departamento)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    deleteDepartamento(id: number) {
        return this._http.delete(this.myAppUrl + "api/Departamento/Delete/?pCodigo=" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);
    }

    errorHandler(error: Response) {
        console.log(error);
        return Observable.throw(error);
    }
}