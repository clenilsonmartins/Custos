import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { FetchEmployeeComponent } from '../fetchemployee/fetchemployee.component';
import { EmployeeService } from '../../services/empservice.service';

@Component({
    selector: 'createemployee',
    templateUrl: './AddEmployee.component.html'
})

export class createemployee implements OnInit {
    employeeForm: FormGroup;
    title: string = "Create";
    codigo: number;
    errorMessage: any;

    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
        private _employeeService: EmployeeService, private _router: Router) {
        if (this._avRoute.snapshot.params["codigo"]) {
            this.codigo = this._avRoute.snapshot.params["codigo"];
        }

        this.employeeForm = this._fb.group({
            codigo: [0, [Validators.required]],
            nome: ['', [Validators.required]],
            email: ['', [Validators.required]]
        })
    }

    ngOnInit() {
        if (this.codigo > 0) {
            this.title = "Edit";
            this._employeeService.getEmployeeById(this.codigo)
                .subscribe(resp => this.employeeForm.setValue(resp)
                , error => this.errorMessage = error);
        }
    }

    save() {

        if (!this.employeeForm.valid) {
            return;
        }

        if (this.title == "Create") {
            this._employeeService.saveEmployee(this.employeeForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/Post']);
                }, error => this.errorMessage = error)
        }
        else if (this.title == "Edit") {
            this._employeeService.updateEmployee(this.employeeForm.value)
                .subscribe((data) => {
                    this._router.navigate(['/Put']);
                }, error => this.errorMessage = error) 
        }
    }

    cancel() {
        this._router.navigate(['/GetFuncionarios']);
    }

    get nome() { return this.employeeForm.get('nome'); }
    get email() { return this.employeeForm.get('email'); }
}