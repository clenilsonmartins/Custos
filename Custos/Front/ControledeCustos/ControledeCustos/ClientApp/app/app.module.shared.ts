import { NgModule } from '@angular/core';
import { FuncionarioService } from './components/funcionario/Services/funcionarioservice.service'
import { DepartamentoService } from './components/departamento/Services/departamentoservice.service'
import { MovimentacaoService } from './components/movimentacao/Services/movimentacaoservice.service'
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/funcionario/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchFuncionarioComponent } from '../app/components/funcionario/fetchFuncionario/fetchFuncionario.component';
import { createFuncionario } from '../app/components/funcionario/addFuncionario/AddFuncionario.component';
import { FetchDepartamentoComponent } from '../app/components/departamento/fetchDepartamento/fetchDepartamento.component';
import { createDepartamento } from '../app/components/departamento/addDepartamento/AddDepartamento.component';
import { FetchMovimentacaoComponent } from '../app/components/movimentacao/fetchmovimentacao/fetchmovimentacao.component';
import { createMovimentacao } from '../app/components/movimentacao/addmovimentacao/Addmovimentacao.component';



@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        FetchFuncionarioComponent ,
        createFuncionario,
        FetchDepartamentoComponent,
        createDepartamento,
        FetchMovimentacaoComponent,
        createMovimentacao
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'Funcionario', component: FetchFuncionarioComponent },
            { path: 'funcionario/edit', component: createFuncionario },
            { path: 'funcionario/edit/:codigo', component: createFuncionario },
            { path: 'Departamento', component: FetchDepartamentoComponent },
            { path: 'departamento/edit', component: createDepartamento },
            { path: 'departamento/edit/:codigo', component: createDepartamento },
            { path: 'Movimentacao', component: FetchMovimentacaoComponent },
            { path: 'movimentacao/edit', component: createMovimentacao },
            { path: 'movimentacao/edit/:codigo', component: createMovimentacao},
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [FuncionarioService, DepartamentoService, MovimentacaoService]
})
export class AppModuleShared {
}
