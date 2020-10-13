import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { EmployeeService } from "../services/employee.service";

@Component({
  selector: "employee-table",
  templateUrl: "employeeTable.component.html",
})
export class EmployeeTableComponent implements OnInit {
  employees = [];
  managers = [];
  selectedManager: {};

  constructor(private service: EmployeeService, private router: Router) {}

  ngOnInit() {
    this.service.getEmployees(null).subscribe((emp) => {
      this.employees = emp;
      this.managers = emp;
    });
  }

  getEmployeesByManager(managerId: string) {
    this.service
      .getEmployee(managerId)
      .subscribe((e) => (this.selectedManager = e));

    this.service
      .getEmployees(managerId)
      .subscribe((emp) => (this.employees = emp));
  }
}
