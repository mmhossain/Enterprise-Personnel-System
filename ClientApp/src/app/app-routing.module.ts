import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { EmployeeTableComponent } from "./employees/employeeTable.component";
import { EmployeeDetailComponent } from "./employees/employeeDetail.component";

const routes: Routes = [
  { path: "employees/new", component: EmployeeDetailComponent },
  { path: "employees/:id", component: EmployeeDetailComponent },
  { path: "employees", component: EmployeeTableComponent },
  { path: "", component: EmployeeTableComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
