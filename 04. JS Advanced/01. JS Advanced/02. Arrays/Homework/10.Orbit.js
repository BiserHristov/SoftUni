function Orbit(input) {
    let rows = input[0];
    let cols = input[1];
    let starRow = input[2];
    let starCol = input[3];

    let array = FillMatrix();
    let mark = 1;
    array[starRow][starCol] = mark;

    mark++;
    let counter = 3; //counter of filled cells around current cell/s
    //starting cell is left-upper according star cell
    starRow--;
    starCol--;

    //for-loop to maximum number
    for (var i = 0; i < Math.max(rows, cols); i++) {
        //variable whisch shows if there all of current cells are outside of array
        let upRow = true;
        let downRow = true;
        let leftCol = true;
        let rightCol = true;

        for (var indexCol = starCol; indexCol < starCol + counter; indexCol++) {

            //up - Row
            if (isInside(starRow, indexCol)) {
                array[starRow][indexCol] = mark;
                upRow = false;

            }

            //down - Row
            if (isInside(starRow + counter - 1, indexCol)) {
                array[starRow + counter - 1][indexCol] = mark;
                downRow = false;

            }

        }

        for (var indexRow = starRow; indexRow < starRow + counter; indexRow++) {

            //left column
            if (isInside(indexRow, starCol)) {
                array[indexRow][starCol] = mark;
                leftCol = false;

            }

            //right column
            if (isInside(indexRow, starCol + counter - 1)) {
                array[indexRow][starCol + counter - 1] = mark;
                rightCol = false;

            }
        }


        if (upRow && downRow &&
            leftCol && rightCol) {
            break;
        }
        counter += 2;
        mark++;
        starRow--;
        starCol--;
    }

    PrintMatrix();

    function PrintMatrix() {
        array.forEach(row => {
            console.log(row.join(' '));
        });
    }
    function isInside(row, col) {
        if (row >= 0 && row < array.length &&
            col >= 0 && col < array[0].length) {
            return true;
        }
        return false;

    }

    function FillMatrix() {
        let arr = [];
        let arrRow = []
        for (var i = 0; i < rows; i++) {
            for (var j = 0; j < cols; j++) {
                arrRow.push(0);
            }
            arr.push(arrRow);
            arrRow = [];
        }

        return arr;
    }


}

Orbit(
    [4, 4, 0, 0]
)

Orbit(
    [5, 5, 2, 2]
)

Orbit(
    [3, 3, 2, 2]
)

