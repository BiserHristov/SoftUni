function SpiralMatrix(rows, cols) {

    let array = FillMatrix(rows, cols);
    let row = 0;
    let col = 0;
    let counter = 1;

    while (true) {
        //horizontal left-right
        while (isInside(row, col) &&
            array[row][col] == 0) {
            array[row][col] = counter;
            col++;
            counter++;
        }
        col--;
        row++;

        //vertical up-down
        while (isInside(row, col) &&
            array[row][col] == 0) {
            array[row][col] = counter;
            row++;
            counter++;
        }
        row--;
        col--;

        //horizontal right-left
        while (isInside(row, col) &&
            array[row][col] == 0) {
            array[row][col] = counter;
            col--;
            counter++;
        }
        col++;
        row--;


        //vertical down-up
        while (isInside(row, col) &&
            array[row][col] == 0) {
            array[row][col] = counter;
            row--;
            counter++;
        }
        row++;
        col++;

        if (array[row][col] != 0) {
            break;
        }
    }

    PrintMatrix();


    function FillMatrix(curRows, curCols) {
        let arr = [];
        let arrRow = []
        for (var i = 0; i < curRows; i++) {
            for (var j = 0; j < curCols; j++) {
                arrRow.push(0);
            }
            arr.push(arrRow);
            arrRow = [];
        }

        return arr;
    }


    function isInside(row, col) {
        if (row >= 0 && row < array.length &&
            col >= 0 && col < array[0].length) {
            return true;
        }
        return false;

    }

    function PrintMatrix() {
        array.forEach(row => {
            console.log(row.join(' '));
        });
    }
}

SpiralMatrix(5, 5);
SpiralMatrix(3, 3);