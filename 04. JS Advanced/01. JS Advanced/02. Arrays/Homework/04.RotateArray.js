function RotateArray(arr) {
    let count = arr.pop();

    for (let index = 0; index < count % arr.length; index++) {

        arr.unshift(arr.pop());
    }

    console.log(arr.join(' '));
}

RotateArray(['1', 
'2', 
'3', 
'4', 
'2']
)