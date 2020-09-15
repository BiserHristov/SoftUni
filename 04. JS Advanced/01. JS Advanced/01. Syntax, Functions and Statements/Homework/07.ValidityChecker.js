function CalculateDistance(arr) {
    let x1 = arr[0];
    let y1 = arr[1];
    let x2 = arr[2];
    let y2 = arr[3];

    let difX = Math.abs(x1 - x2);
    let difY = Math.abs(y1 - y2);

    Calculate(x1, y1, 0, 0);
    Calculate(x2, y2, 0, 0);
    Calculate(x1, y1, x2, y2);


    function Calculate(x1, y1, x2, y2) {
        let distanceToZero = GetDistance(x1, y1, x2, y2);
        let validationText = ValidateDistance(distanceToZero);
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${validationText}`);
    }


    function GetDistance(x1, y1, x2, y2) {
        return Math.sqrt((x1 - x2) ** 2 + (y1 - y2) ** 2);
    }

    function ValidateDistance(distance) {
        return Number.isInteger(distance) ? 'valid' : 'invalid';
    }

}

CalculateDistance([3, 0, 0, 4]);
CalculateDistance([2, 1, 1, 1]);
