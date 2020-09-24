function SortArray(arr){

arr=arr.sort((a,b)=>a.length-b.length || a.localeCompare(b))

console.log(arr.join('\n'));
}

SortArray(
['alpha', 
'beta', 
'gamma'
]
)

SortArray(
    ['Isacc', 
    'Theodor', 
    'Jack', 
    'Harrison', 
    'George']
    
    )

    SortArray(
        ['test', 
        'Deny',
        'Default',
        'omen'
        ]
        )