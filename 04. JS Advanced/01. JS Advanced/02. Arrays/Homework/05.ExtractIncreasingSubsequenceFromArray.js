function ExtractIncreasingSubsequence(array) {

    let maxNum = Number.MIN_SAFE_INTEGER;
    array=array.reduce((acc, x) => {
        if (x >= maxNum) {
            maxNum=x;
            acc.push(x);
        }

        return acc;
    }, [])

    console.log(array.join('\n'))
    //     let biggestNum=array[0];
    //     console.log(biggestNum);

    // for (let index = 1; index < array.length; index++) {
    //     const element = array[index];
    //     if(element>=biggestNum)
    //     {
    //         biggestNum=element;
    //         console.log(biggestNum)
    //     }
    // }
}



ExtractIncreasingSubsequence([
    1,
    3,
    8,
    4,
    10,
    12,
    3,
    2,
    24]
)

ExtractIncreasingSubsequence([20,
    3,
    2,
    15,
    6,
    1]
)
ExtractIncreasingSubsequence([
    1,
    2,
    3,
    4]
)    