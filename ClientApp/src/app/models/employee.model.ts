import { ERole } from "./eRole.model";
export class Employee {
  constructor(
    public employeeId?: number,
    public firstName?: string,
    public lastName?: string,
    public managerId?: string,
    public manager?: Employee,
    public eRoles?: ERole[]
  ) {}
}
