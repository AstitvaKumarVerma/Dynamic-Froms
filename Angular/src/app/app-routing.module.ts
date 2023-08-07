import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DynamicStudentFormComponent } from './dynamic-student-form/dynamic-student-form.component';

const routes: Routes = [
  {
    path:'',
    component: DynamicStudentFormComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
