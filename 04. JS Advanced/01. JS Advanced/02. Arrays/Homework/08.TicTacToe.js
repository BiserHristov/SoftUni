function TicTacToe(arr) {
    let dashboard = [
        [false, false, false],
        [false, false, false],
        [false, false, false]]

    let mark = 'X';
    let markCounter=0;
    for (let i = 0; i < arr.length; i++) {
        if (markCounter==9) {
            break;
        }
        let move = arr[i].split(' ');
        let moveRow = move[0]
        let moveCol = move[1]

        if (dashboard[moveRow][moveCol] != false) {
            console.log("This place is already taken. Please choose another!");
            continue;
        }

        dashboard[moveRow][moveCol] = mark;
        markCounter++;
        if (CheckForWin()) {
            console.log(`Player ${mark} wins!`)
            PrintDashboard();
            return;
        }

        mark=='X'? mark='O' : mark='X';

    }

    console.log("The game ended! Nobody wins :(");
    PrintDashboard();

    function PrintDashboard(){
        dashboard.forEach(el => {
            console.log(el.join('\t'))
        });
    }
    function CheckForWin() {
        for (var row = 0; row < dashboard[0].length; row++) {

            if (dashboard[row][0] != false) {
                const allEqual = dashboard[row].every(v => v === dashboard[row][0])
                if (allEqual) {
                    return true;
                }
            }

            if (row != 0) {
                continue;
            }

            let colSet = new Set();
            let leftDiagonalSet= new Set();
            let righDiagonalSet= new Set();

            for (var i = 0; i < dashboard[0].length; i++) {

                colSet.add(dashboard[i][row])
                leftDiagonalSet.add(dashboard[i][i])
                righDiagonalSet.add(dashboard[i][dashboard[0].length-1-i])
            }

            if ((colSet.size == 1 && colSet.values().next().value != false)||
                (leftDiagonalSet.size == 1 && leftDiagonalSet.values().next().value != false) ||
                (righDiagonalSet.size == 1 && righDiagonalSet.values().next().value != false)) {
                return true;
            }

        }
    }

}

TicTacToe(
    ["0 1",
        "0 0",
        "0 2",
        "2 0",
        "1 0",
        "1 1",
        "1 2",
        "2 2",
        "2 1",
        "0 0"]
)
console.log('*'.repeat(20))

TicTacToe(
    ["0 0",
    "0 0",
    "1 1",
    "0 1",
    "1 2",
    "0 2",
    "2 2",
    "1 2",
    "2 2",
    "2 1"]   
)

console.log('*'.repeat(20))

TicTacToe(
    ["0 1",
 "0 0",
 "0 2",
 "2 0",
 "1 0",
 "1 2",
 "1 1",
 "2 1",
 "2 2",
 "0 0"]
   
)
