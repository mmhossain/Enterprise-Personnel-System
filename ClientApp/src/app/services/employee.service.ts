import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Employee } from "../models/employee.model";
import { ERole } from "./../models/eRole.model";

const employeesUrl = "/api/employees";

@Injectable()
export class EmployeeService {
  constructor(private http: HttpClient) {}

  getEmployee(id: string) {
    return this.http.get<Employee>(`${employeesUrl}/${id}`);
  }

  getEmployees(managerId: string) {
    let url = employeesUrl;
    if (managerId) url = `${employeesUrl}?managerId=${managerId}`;

    return this.http.get<Employee[]>(url);
  }

  getManagers(excludeEmployeeId: string) {
    let url = `${employeesUrl}/managers/${excludeEmployeeId}`;
    return this.http.get<Employee[]>(url);
  }

  getAllRoles() {
    const url = `${employeesUrl}/roles`;
    return this.http.get<ERole[]>(url);
  }

  getRolesByEmployeeId(empId: string) {
    const url = `${employeesUrl}/roles/${empId}`;
    return this.http.get<ERole[]>(url);
  }

  createEmployee(emp: Employee) {
    let data = {
      employeeId: emp.employeeId,
      firstName: emp.firstName,
      lastName: emp.lastName,
      managerId: emp.managerId,
      employeeRoles: [],
    };

    if (emp.eRoles && emp.eRoles.length > 0) {
      let roles = [];
      for (let rId of emp.eRoles)
        roles.push({ employeeId: emp.employeeId, eRoleId: rId.eRoleId });

      data.employeeRoles = roles;
    }

    return this.http.post<number>(employeesUrl, data);
  }

  updateEmployee(emp: Employee) {
    let data = {
      employeeId: emp.employeeId,
      firstName: emp.firstName,
      lastName: emp.lastName,
      managerId: emp.managerId,
      employeeRoles: [],
    };

    if (emp.eRoles && emp.eRoles.length > 0) {
      let roles = [];
      for (let rId of emp.eRoles)
        roles.push({ employeeId: emp.employeeId, eRoleId: rId.eRoleId });

      data.employeeRoles = roles;
    }

    return this.http.put<number>(`${employeesUrl}/${emp.employeeId}`, data);
  }
}
