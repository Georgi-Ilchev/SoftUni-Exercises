function solve(input, criteria) {
    let employees = JSON.parse(input);
    let [key, value] = criteria.split('-');

    //1
    // employees
    //     .filter(x => x[key] == value || key == 'all')
    //     .forEach((x, index) => {
    //         console.log(`${index}. ${x.first_name} ${x.last_name} - ${x.email}`);
    //     });

    //2
    employees
        .filter(filterEmployees)
        .forEach((x, index) => {
            console.log(`${index}. ${x.first_name} ${x.last_name} - ${x.email}`);
        });

    function filterEmployees(employee) {
        return employee[key] == value || key == 'all'
    }
}


solve(`[{
    "id": "1",
    "first_name": "Ardine",
    "last_name": "Bassam",
    "email": "abassam0@cnn.com",
    "gender": "Female"
  }, {
    "id": "2",
    "first_name": "Kizzee",
    "last_name": "Jost",
    "email": "kjost1@forbes.com",
    "gender": "Female"
  },  
{
    "id": "3",
    "first_name": "Evanne",
    "last_name": "Maldin",
    "email": "emaldin2@hostgator.com",
    "gender": "Male"
  }]`,
    'gender-Female'
)