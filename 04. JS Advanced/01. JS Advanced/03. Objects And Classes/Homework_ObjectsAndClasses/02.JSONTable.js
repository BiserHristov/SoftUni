function JSNOTable(input){
    let result='<table>\n';
    for (let index = 0; index < input.length; index++) {
        const element = JSON.parse(input[index]);
      
          result+='\t<tr>\n';
          result+=`\t\t<td>${element.name}</td>\n`;
          result+=`\t\t<td>${element.position}</td>\n`;
          result+=`\t\t<td>${Number(element.salary)}</td>\n`;
          result+='\t</tr>\n';

       
        
    }
    result+='</table>';

    console.log(result);

}

JSNOTable([
'{"name":"Pesho","position":"Promenliva","salary":100000}',
'{"name":"Teo","position":"Lecturer","salary":1000}',
'{"name":"Georgi","position":"Lecturer","salary":1000}'
]
)