function DiagonalAttack(input) {

    let arr=[];

    input.forEach(el => {
        arr.push(el.split(' ').map(Number));
    });


    let leftDiagonalSum = 0;
    let righDiagonalSum = 0;

    for (var row = 0; row < arr[0].length; row++) {

            leftDiagonalSum += Number(arr[row][row]);
            righDiagonalSum += Number(arr[row][arr[0].length - 1 - row]);
        

    }

    if (leftDiagonalSum!=righDiagonalSum) {
        PrintMatrix();
        return;
    }

    for (var row = 0; row < arr[0].length; row++) {

        for (var col = 0; col < arr[0].length; col++) {
            if (row==col ||
                row==arr[0].length - 1 - col) {
                continue;
            }
            arr[row][col]=leftDiagonalSum;
        }

    }

    PrintMatrix();

  function PrintMatrix(){
    arr.forEach(row => {
        console.log(row.join(' '));
    });
  }
}

DiagonalAttack(
    ['5 3 12 3 1',
    '11 4 23 2 5',
    '101 12 3 21 10',
    '1 4 5 2 2',
    '5 22 33 11 1']
    
)
console.log('*'.repeat(30));

DiagonalAttack(
['1 1 1',
'1 1 1',
'1 1 0']


    
)