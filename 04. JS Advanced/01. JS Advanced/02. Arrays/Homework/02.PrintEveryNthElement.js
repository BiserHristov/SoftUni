function PrintElement(arr){
    let step= Number(arr.pop());

    arr.forEach((element,index) => {
        if (index%step==0) {
            console.log(element);
        }
    });
}

PrintElement([
'5', 
'20', 
'31', 
'4', 
'20', 
'2']
)