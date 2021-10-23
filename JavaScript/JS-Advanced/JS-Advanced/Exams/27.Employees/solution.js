function solveClasses() {
    class Developer {
        constructor(firstName, lastName) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.baseSalary = 1000;
            this.tasks = [];
            this.experience = 0;
        }

        addTask(id, taskName, priority) {
            let task = {
                id,
                taskName,
                priority
            };

            if (priority === 'high') {
                this.tasks.unshift(task);
            } else {
                this.tasks.push(task);
            }

            return `Task id ${id}, with ${priority} priority, has been added.`;
        }

        doTask() {
            const task = this.tasks.shift();

            if (task) {
                return task.taskName;
            }

            return `${this.firstName}, you have finished all your tasks. You can rest now.`;
        }

        getSalary() {
            return `${this.firstName} ${this.lastName} has a salary of: ${this.baseSalary}`;
        }

        reviewTasks() {
            return `Tasks, that need to be completed:\n${this.tasks
                .map(({ id, taskName, priority }) => `${id}: ${taskName} - ${priority}`)
                .join('\n')}`;
        }
    }

    class Junior extends Developer {
        constructor(firstName, lastName, bonus, experience) {
            super(firstName, lastName);
            this.baseSalary = this.baseSalary + bonus;
            this.experience = experience;
        }

        learn(years) {
            this.experience += years;
        }
    }

    class Senior extends Developer {
        constructor(firstName, lastName, bonus, experience) {
            super(firstName, lastName);
            this.baseSalary = this.baseSalary + bonus;
            this.experience = experience + 5;
        }

        changeTaskPriority(taskId) {
            let taskIndex = this.tasks.findIndex((t) => t.id === taskId);

            if (taskIndex !== -1) {
                const task = this.tasks[taskIndex];
                this.tasks.splice(taskIndex, 1);

                if (task.priority === 'high') {
                    task.priority = 'low';
                    this.tasks.push(task);
                } else {
                    task.priority = 'high';
                    this.tasks.unshift(task);
                }
                return task;
            }
        }
    }

    return {
        Developer,
        Junior,
        Senior
    }
}