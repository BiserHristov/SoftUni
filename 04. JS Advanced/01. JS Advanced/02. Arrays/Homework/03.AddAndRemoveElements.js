function AddRemoveElement(arr) {
    let num = 1;
    let result = [];
    arr.forEach(x => {
        if (x == 'add') {
            result.push(num);

        } else if (x == 'remove') {
            result.pop();
        }
        num++;
    });

    if (result.length == 0) {
        console.log('Empty');
    } else {
        result.forEach(x => console.log(x));
    }
}

AddRemoveElement(['add',
    'add',
    'remove',
    'add',
    'add']
)