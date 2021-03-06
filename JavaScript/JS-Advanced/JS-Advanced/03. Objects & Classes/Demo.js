//cloning object
let person1 = {
    firstName: 'gosho',
    age: 20,
    //grades =[2, 3, 4, 5],
};

let person2 = Object.assign({}, person1);

console.log(person1);
console.log(person2);

person1.firstName = 'tosho';

console.log(person1);
console.log(person2);


//delete
delete person1.age;

console.log(person1);

//get values and keys 
console.log(Object.keys(person1));
console.log(Object.values(person1));

Object.keys(person1).forEach(key => {
    console.log(`${key} --> ${person1[key]}`)
});

//if has ownproperty
if (person1.hasOwnProperty('firstName')) {
    console.log('Yes, he has!')
} else {
    console.log('No');
}

if (person1['firstName']) {
    console.log('Yes, he has!')
} else {
    console.log('No');
}

//for in
for (let key in person1) {
    console.log(key);
}

for (let key in person1) {
    console.log(person1[key]);
}

for (let key in person1) {
    console.log(`person.${key} = ${person[key]}`);
}

//for of
for (const key of Object.keys(person1)) {
    console.log(key);
}

let res = Object.entries(person1);
console.log(res);

let samePerson = Object.fromEntries(res);
console.log(samePerson);


//JSON
let received = '{ "manager":{"firstName":"John","lastName":"Doe"}, "employee":{"firstName":"Gosho","lastName":"Zoe"}}';

let data = JSON.parse(received);
console.log(data.manager.firstName);
console.log(data.employee.firstName);

//2
let personJson = JSON.stringify(person1);
console.log(personJson);

//3
let clonedPerson = JSON.parse(JSON.stringify(person1));
console.log(clonedPerson);


//
// Object.keys();
// Object.values();
// Object.entries() => [key,value];