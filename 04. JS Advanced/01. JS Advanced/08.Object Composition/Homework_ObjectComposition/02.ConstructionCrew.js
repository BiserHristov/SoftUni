function solve(input) {
    let { weight, experience, levelOfHydrated, dizziness } = input;
    if (dizziness) {
        input.levelOfHydrated += 0.1 * weight * experience;
        input.dizziness = false;
    }
    return input;

}


let result= solve({
    weight: 80,
    experience: 1,
    levelOfHydrated: 0,
    dizziness: true
});

console.log(result);