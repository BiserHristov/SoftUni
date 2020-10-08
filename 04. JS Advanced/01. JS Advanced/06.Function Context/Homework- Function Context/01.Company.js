class Company {
    constructor() {
        this.departments = [];
    }

    addEmployee(username, salary, position, department) {
        if (!username ||
            !salary ||
            Number(salary) < 0 ||
            !position ||
            !department) {
            throw new Error("Invalid input!");
        }

        if (!this.departments[department]) {
            this.departments[department] = []
        }

        this.departments[department].push({ username, salary, position })
        return `New employee is hired. Name: ${username}. Position: ${position}`;
    }

    bestDepartment() {

        let departmentsAvgSal = {};

        Object.entries(this.departments).forEach(([key, value]) => {

            let avgSalary = (value.reduce(function (a, x) {
                return a += x.salary;
            }, 0) / value.length).toFixed(2);

            departmentsAvgSal[key] = avgSalary;

        });


        let sorted = Object.entries(departmentsAvgSal).sort((cur, next) => {
            return next.salary - cur.salary
        })

        let result = `Best Department is: ${sorted[0][0]}\n`
        result += `Average salary: ${sorted[0][1]}\n`

        this.departments[sorted[0][0]]
        .sort((cur,next)=>{
            return next.salary-cur.salary || cur.username.localeCompare(next.username)
        })
        .forEach(e=>result += `${e.username} ${e.salary} ${e.position}\n`)
        
        
        
        return result.trim();
        

    }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());
