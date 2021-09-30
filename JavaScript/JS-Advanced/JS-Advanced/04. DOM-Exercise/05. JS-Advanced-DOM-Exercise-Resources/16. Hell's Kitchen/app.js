function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {
      let arr = JSON.parse(document.querySelector('#inputs textarea').value);
      let objWinner = findBestRestaurant(arr);
      document.querySelector('#bestRestaurant>p').textContent = getMsgRest(objWinner);
      document.querySelector('#workers>p').textContent = getMsgEmp(objWinner.workers);
   }

   function getMsgRest(objWinner) {
      return `Name: ${objWinner.name} Average Salary: ${objWinner.avgSalary.toFixed(2)} Best Salary: ${objWinner.maxSalary.toFixed(2)}`;
   }

   function getMsgEmp(workers) {
      return workers.map(w => `Name: ${w.worker} With Salary: ${w.salary}`).join(' ');
   }

   function findBestRestaurant(arr) {
      let resultRestaurants = arr.reduce((acc, e) => {
         let [restaurant, ...workers] = e.split(/(?: - )|(?:, )/g);
         workers = workers.map(w => {
            let [worker, salary] = w.split(' ');
            return {
               worker: worker,
               salary: +salary
            };
         });
         let foundRestraunt = acc.find(r => r.name === restaurant);
         if (foundRestraunt) {
            foundRestraunt.workers = foundRestraunt.workers.concat(workers);
         } else {
            acc.push({
               name: restaurant,
               workers: workers
            });
         }
         return acc;
      }, []);

      resultRestaurants.forEach((el, idx) => {
         el.inputOrder = idx;
         el.avgSalary = el.workers.reduce((acc, el) => acc + el.salary, 0) / el.workers.length;
         el.maxSalary = Math.max(...el.workers.map(w => w.salary));
      });

      resultRestaurants.sort((a, b) => b.avgSalary - a.avgSalary || a.inputOrder - b.inputOrder);
      let bestRestaurant = resultRestaurants[0];
      bestRestaurant.workers.sort((a, b) => b.salary - a.salary);

      return bestRestaurant;
   }
}




function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {
      let input = JSON.parse(document.querySelector('textarea').value);
      let bestRestaurantOutput = document.querySelector('#bestRestaurant p');
      let bestWorkersOutput = document.querySelector('#workers p');

      let restaurant = [0, 0, 0, 0];

      input.forEach(line => {
         line = line.match(/[^-,\s]+/g);
         let restaurantName = line.shift();
         let workers = line.filter(e => isNaN(e));
         let salaries = line.filter(e => !isNaN(e));

         if (restaurant[0] === restaurantName) {
            restaurant[2].push(...workers);
            restaurant[3].push(...salaries);
            restaurant[1] = calcAverageSalary(restaurant[3]);
         } else {
            let averageSalary = calcAverageSalary(salaries);
            if (averageSalary > restaurant[1]) {
               restaurant[0] = restaurantName;
               restaurant[1] = averageSalary;
               restaurant[2] = workers;
               restaurant[3] = salaries;
            }
         }
      });

      function calcAverageSalary(salaries) {
         return salaries.reduce((a, b) => Number(a) + Number(b)) / salaries.length;
      }
      function calcHighestSalary() {
         return Math.max.apply(null, restaurant[3]);
      }
      function sortSalaries() {
         let workersAndSalaries = {};
         restaurant[2].forEach((e, i) => {
            workersAndSalaries[e] = restaurant[3][i];
         });
         let sorted = Object.entries(workersAndSalaries).sort((a, b) => b[1] - a[1]);
         print(sorted);
      }
      sortSalaries();

      function print(sorted) {
         bestRestaurantOutput.textContent =
            `Name: ${restaurant[0]} Average Salary: ${(restaurant[1]).toFixed(2)} Best Salary: ${(calcHighestSalary()).toFixed(2)}`
         sorted.forEach(([name, salary]) => bestWorkersOutput.textContent += `Name: ${name} With Salary: ${salary} `);
      }
   }
}