function toStringExtension() {
    class Person {
        constructor(name, email) {
            this.name = name;
            this.email = email;
        }

        toString(value) {
            let className = this.constructor.name;
            return `${className} (name: ${this.name}, email: ${this.email}${value === undefined ? '' : `, ${value}`})`;
        }
    }

    class Teacher extends Person {
        constructor(name, email, subject) {
            super(name, email);
            this.subject = subject;
        }

        toString() {
            return super.toString(`subject: ${this.subject}`);
        }
    }

    class Student extends Person {
        constructor(name, email, course) {
            super(name, email);
            this.course = course;
        }

        toString() {
            return super.toString(`course: ${this.course}`);
        }
    }

    return {
        Person,
        Teacher,
        Student
    }
}
