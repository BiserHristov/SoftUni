function SystemComponents(input) {
    let result = {};
    for (let i = 0; i < input.length; i++) {
        const element = input[i];
        let [system, component, subComponent] = element.split(' | ');

        if (!result[system]) {
            result[system] = {};
            // result[system][component] = [];
        }
        if (!result[system][component]) {
            result[system][component] = [];
        }
        result[system][component].push(subComponent);

    }

    //DOESNT WORKS!!

    // Object.entries(result)
    //     .sort((curr, next) => Object.keys(next[1]).length - Object.keys(curr[1]).length || curr[0].localeCompare(next[0]))
    //     .sort((a, b) => Object.entries(b[1]).length - Object.entries(a[1]).length)
    //     .forEach(([system, components]) => {
    //         console.log(system)
    //         Object.entries(components).forEach(([comp, subcomp]) => {
    //             console.log(`|||${comp}`)
    //             subcomp.forEach(e => console.log(`||||||${e}`))

    //         });
    //     })


    
    Object.entries(result)
    .sort((curr, next) => Object.keys(next[1]).length - Object.keys(curr[1]).length || curr[0].localeCompare(next[0]))
    .forEach(([system, component]) => {
        console.log(system);
        Object.entries(component).sort((curr, next) => next[1].length - curr[1].length)
            .forEach(([component, subcomponents]) => {
                console.log(`|||${component}`)
                subcomponents.forEach(sub => {
                    console.log(`||||||${sub}`)
                });
            })
    });

}

SystemComponents([
    'SULS | Main Site | Home Page',
    'SULS | Main Site | Login Page',
    'SULS | Main Site | Register Page',
    'SULS | Judge Site | Login Page',
    'SULS | Judge Site | Submittion Page',
    'Lambda | CoreA | A23',
    'SULS | Digital Site | Login Page',
    'Lambda | CoreB | B24',
    'Lambda | CoreA | A24',
    'Lambda | CoreA | A25',
    'Lambda | CoreC | C4',
    'Indice | Session | Default Storage',
    'Indice | Session | Default Security'
])

