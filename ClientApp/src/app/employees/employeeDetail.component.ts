import { Component, OnInit } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { EmployeeService } from "../services/employee.service";

@Component({
  selector: "employee-detail",
  templateUrl: "employeeDetail.component.html",
})
export class EmployeeDetailComponent implements OnInit {
  employee = {};
  managers = [];
  allRoles = [];
  selectedRoles = [];
  employeeId;

  constructor(
    private service: EmployeeService,
    private router: Router,
    route: ActivatedRoute
  ) {
    this.employeeId = route.snapshot.paramMap.get("id");
  }

  ngOnInit() {
    this.service
      .getManagers(this.employeeId)
      .subscribe((mgrs) => (this.managers = mgrs));

    this.service.getAllRoles().subscribe((r) => {
      this.allRoles = r;
    });

    if (this.employeeId) {
      this.service.getEmployee(this.employeeId).subscribe((e) => {
        this.employee = e;
      });

      this.service.getRolesByEmployeeId(this.employeeId).subscribe((roles) => {
        this.selectedRoles = this.allRoles.filter(
          (ar) => roles.findIndex((r) => r.eRoleId == ar.eRoleId) != -1
        );
      });
    }
  }

  save(employee) {
    employee.eRoles = this.selectedRoles;

    if (!this.employeeId)
      this.service.createEmployee(employee).subscribe((e) => {});
    else this.service.updateEmployee(employee).subscribe((e) => {});

    // this.router.navigateByUrl("/");
    window.location.replace("/");
  }
}
