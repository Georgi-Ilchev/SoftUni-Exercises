class CheckingAccount {
    constructor(clientId, email, firstName, lastName) {
        this.clientId = clientId;
        this.email = email;
        this.firstName = firstName;
        this.lastName = lastName;
    }

    get clientId() {
        return this._clientId;
    }
    set clientId(value) {
        if (!/^\d{6}$/g.test(value)) {
            throw new TypeError("Client ID must be a 6-digit number")
        }
        return this._clientId = value;
    }


    get email() {
        return this._email;
    }
    set email(value) {
        let emailPattern = /[A-Za-z0-9]+@[A-Za-z.]+$/g;
        if (!emailPattern.test(value)) {
            throw new TypeError('Invalid e-mail');
        }
        return this._email = value;
    }


    get firstName() {
        return this._firstName;
    }
    set firstName(value) {
        if (value.length < 3 || value.length > 20) {
            throw new TypeError(`First name must be between 3 and 20 characters long`);
        }

        let pattern = /[A-Za-z]/g;
        if (!pattern.test(value)) {
            throw new TypeError(`First name must contain only Latin characters`);
        }
        return this._firstName = value;
    }


    get lastName() {
        return this._lastName;
    }
    set lastName(value) {
        if (value.length < 3 || value.length > 20) {
            throw new TypeError(`Last name must be between 3 and 20 characters long`);
        }

        let pattern = /[A-Za-z]/g;
        if (!pattern.test(value)) {
            throw new TypeError(`Last name must contain only Latin characters`);
        }
        return this._lastName = value;
    }
}

//let acc = new CheckingAccount('1314', 'ivan@some.com', 'Ivan', 'Petrov')
//let acc = new CheckingAccount('131455', 'ivan@', 'Ivan', 'Petrov')
//let acc = new CheckingAccount('131455', 'ivan@some.com', 'I', 'Petrov')
let acc = new CheckingAccount('131455', 'ivan@some.com', 'Ivan', 'P3trov')
