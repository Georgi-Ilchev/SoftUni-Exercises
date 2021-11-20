import { html, render } from './node_modules/lit-html/lit-html.js';

const studentTemplate = (student) => html`
<tr class="${student.match ? 'select' : ''}">
   <td>${student.item.firstName} ${student.item.lastName}</td>
   <td>${student.item.email}</td>
   <td>${student.item.course}</td>
</tr>`;

const root = document.querySelector('tbody');
const input = document.getElementById('searchField');
document.getElementById('searchBtn').addEventListener('click', onSearch);
let students;

start();

async function start() {
   const response = await fetch('http://localhost:3030/jsonstore/advanced/table');
   const data = await response.json();
   students = Object.values(data).map(s => ({ item: s, match: false }));

   update();
}

function onSearch() {
   const value = input.value.trim().toLocaleLowerCase();

   for (const student of students) {
      student.match = Object.values(student.item).some(v => value && v.toLocaleLowerCase().includes(value));
   }

   update();
}

function update() {
   render(students.map(studentTemplate), root);
}