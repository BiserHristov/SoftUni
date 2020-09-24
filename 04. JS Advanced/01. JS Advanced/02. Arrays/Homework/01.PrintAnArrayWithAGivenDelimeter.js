function PrintArray(arr){
    let delimeter= arr.pop();
console.log(arr.join(delimeter));
}

PrintArray([
'One', 
'Two', 
'Three', 
'Four', 
'Five', 
'-']
);