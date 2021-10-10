class Company {
    constructor() {
        this.departments = [];
    }

    addEmployee(username, salary, position, department) {
        if ([...arguments].some(a => a === null || a === undefined || a === '' || salary < 0)) {
            throw new Error(`Invalid input!`);
        } else {
            const newEmployee = {
                username: username,
                salary: salary,
                position: position,
                department: department,
            };

            if (this.departments.filter(function (e) { return e.name === department; }).length > 0) {
                for (const existingDeparment of this.departments) {
                    if (existingDeparment.name === department) {
                        existingDeparment.users.push(newEmployee);
                        existingDeparment.totalSalary += salary;
                    }
                }
            } else {
                let newDepartment = {
                    name: department,
                    users: [newEmployee],
                    totalSalary: salary,
                    averageSalary() {
                        return this.totalSalary / this.users.length;
                    },
                };

                this.departments.push(newDepartment);
            }

            return `New employee is hired. Name: ${username}. Position: ${position}`;
        }
    }

    bestDepartment() {
        let bestDepartment = this.departments.sort((a, b) => a.averageSalary - b.averageSalary)[0];
        bestDepartment.users = bestDepartment.users.sort(function (a, b) {
            if (a.username === b.username) {
                return b.username - a.username;
            }

            return a.salary < b.salary ? 1 : -1;
        });

        let result = `Best Department is: ${bestDepartment.name}\nAverage salary: ${bestDepartment.averageSalary().toFixed(2)}`;

        for (const user of bestDepartment.users) {
            result += `\n${user.username} ${user.salary} ${user.position}`;
        }

        return result;
    }
}

// `Best Department is: {best department's name}
// Average salary: {best department's average salary}
// {employee1} {salary} {position}
// {employee2} {salary} {position}
// {employee3} {salary} {position}

try {
    let c = new Company();
    c.addEmployee("Stanimir", 2000, "engineer", "Construction");
    c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
    c.addEmployee("Slavi", 500, "dyer", "Construction");
    c.addEmployee("Stan", 2000, "architect", "Construction");
    c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
    c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
    c.addEmployee("Gosho", 1350, "HR", "Human resources");
    console.log(c.bestDepartment());
} catch (er) {
    console.log(er);
}