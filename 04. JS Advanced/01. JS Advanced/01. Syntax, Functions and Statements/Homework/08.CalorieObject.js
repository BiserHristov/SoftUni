function CalorieObject(arr) {
    let result = {};

    for (let index = 0; index < arr.length; index += 2) {
        const product = arr[index];
        const calories = arr[index + 1];
        result[product]=Number(calories);
    }

    console.log(result);
}

CalorieObject(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);
CalorieObject(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42']);
