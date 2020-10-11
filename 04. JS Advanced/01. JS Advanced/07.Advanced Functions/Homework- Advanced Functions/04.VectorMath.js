solution = {
    add: ([x1, y1], [x2, y2]) => [x1 + x2, y1 + y2],
    multiply: (arr, number)=> [arr[0]*number, arr[1]*number],
            //VECTOR==[X1,Y1]
    length: (vector)=> Math.sqrt(vector[0]**2 + vector[1]**2 ),
    dot: (vector1, vector2)=> vector1[0]*vector2[0] + vector1[1]*vector2[1],
    cross: (vector1, vector2)=> vector1[0]*vector2[1] - vector1[1]*vector2[0],

}



console.log(result.add([1, 1], [1, 0]))
console.log(result.multiply([3.5, -2], 2))
console.log(result.length([3, -4]))
