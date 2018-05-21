import { Component, Inject } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { EmployeeService } from '../../services/empservice.service'

@Component({
    selector: 'fetchemployee',
    templateUrl: './fetchemployee.component.html'
})

export class FetchEmployeeComponent {
    public empList: EmployeeData[];

    constructor(public http: Http, private _router: Router, private _employeeService: EmployeeService) {
        this.getEmployees();
    }

    getEmployees() {
        this._employeeService.getFuncionarios().subscribe(
            data => this.empList = data
        )
    }

    delete(employeeID) {
        var ans = confirm("Do you want to delete customer with Id: " + employeeID);
        if (ans) {
            this._employeeService.deleteEmployee(employeeID).subscribe((data) => {
                this.getEmployees();
            }, error => console.error(error)) 
        }
    }
}

interface EmployeeData {
    codigo: number;
    nome: string;
    email: string;    
}