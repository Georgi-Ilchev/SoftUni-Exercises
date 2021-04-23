function solve(name, age, weight, height) {
    let bmi = Math.round(Number(weight) / ((Number(height) / 100) * (Number(height) / 100)));

    let status = calcStatus(bmi);

    let person = {
        name: name,
        personalInfo: {
            age,
            weight,
            height,
        },
        BMI: bmi,
        status
    };

    if (status == 'obese') {
        person.recommendation = 'admission required';
    }

    return person;

    function calcStatus(bmi) {
        if (bmi < 18.5) {
            return 'underweight';
        } else if (bmi < 25) {
            return 'normal';
        } else if (bmi < 30) {
            return 'overweight';
        } else {
            return 'obese';
        }
    }
}

solve('Peter', 29, 75, 182)