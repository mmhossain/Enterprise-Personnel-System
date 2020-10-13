import { HttpClientModule } from "@angular/common/http";
import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { FormsModule } from "@angular/forms";
import { EmployeeService } from "./services/employee.service";
import { EmployeeTableComponent } from "./employees/employeeTable.component";
import { EmployeeDetailComponent } from "./employees/employeeDetail.component";

@NgModule({
  declarations: [AppComponent, EmployeeTableComponent, EmployeeDetailComponent],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule, FormsModule],
  providers: [EmployeeService],
  bootstrap: [AppComponent],
})
export class AppModule {}
