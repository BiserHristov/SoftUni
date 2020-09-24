function MagicMatrices(array) {
    let sum=array[0].reduce((acc, x) => acc + x);

    for (let row = 0; row < array.length; row++) {
        
        let rowSum=(array[row].reduce((acc, x) => acc + x));
        if (rowSum!=sum) {
            console.log(false);
            return;
        }
        let colSum=0;
        for (var col = 0; col < array.length; col++) {
            colSum+=array[row][col]
            
        }
        if (colSum!=sum) {
            console.log(false);
            return;
        }
    }
    console.log(true);





    // let rowSum = arr[0].reduce((acc, x) => acc + x, 0);

    // for (let row = 1; row < arr.length; row++) {
    //     if (arr[row].reduce((acc, x) => acc + x, 0) != rowSum) {
    //         console.log(false);
    //         return;
    //     }
    // }

    // let colSum = 0

    // for (let col = 0; col < arr.length; col++) {
    //     //let colSum = 0
    //     for (let row = 0; row < arr.length; row++) {
    //         const element = arr[row][col];
    //         colSum += element;
    //     }
    //     if (colSum!=rowSum) {
    //         console.log(false)
    //         return;
    //     }


    // }

    // console.log(true);


}

MagicMatrices([
    [4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]
]
)

MagicMatrices([
    [11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]
])

MagicMatrices([
    [1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]
])
