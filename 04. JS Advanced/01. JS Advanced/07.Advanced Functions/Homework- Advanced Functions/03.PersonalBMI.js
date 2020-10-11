function solve(name, age, weight, height) {

    let personalInfo = { age, weight, height };
    let BMI = Math.round(weight / ((height / 100) ** 2));
    let status = ''

    if (BMI < 18.5) {
        status = 'underweight'
    }
    else if (BMI < 25) {
        status = 'normal'
    }
    else if (BMI < 30) {
        status = 'overweight'
    }
    else if (BMI >= 30) {
        status = 'obese'
    }

    let result = { name, personalInfo, BMI, status }
    if (status == 'obese') {
        result.recommendation = 'admission required';
    }

    return (result);

}

console.log(solve("Peter", 29, 75, 182))
console.log(solve("Honey Boo Boo", 9, 57, 137))
