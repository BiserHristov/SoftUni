function HeroicInventory(input) {
    let heroes = []

    class Hero {

        constructor(name, level, items) {
            this.name = name;
            this.level = level;
            this.items = items;
        }
    }

    for (let index = 0; index < input.length; index++) {
        let [name, level, items] = input[index].split('/').map(x => x.trim());
        level = Number(level);
        items = items ? items.split(',').map(x => x.trim()) : [];
        let hero = new Hero(name, level, items);
        heroes.push(hero);


    }

    console.log(JSON.stringify(heroes))

}





HeroicInventory(
    ['Isacc / 25 / Apple, GravityGun',
        'Derek / 12 / BarrelVest, DestructionSword',
        'Hes / 1 / Desolator, Sentinel, Antara'
    ]
);