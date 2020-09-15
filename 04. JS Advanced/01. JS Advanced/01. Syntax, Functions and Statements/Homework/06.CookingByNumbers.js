function CookingByNumbers(array){

    let number=Number(array[0]);

    for (let index = 1; index < array.length; index++) {
        const element = array[index];

        switch (element) {
            case 'chop':
                number/=2;
                break;

            case 'dice':
                number=Math.sqrt(number);
                 break;

            case 'spice':
                number++;
                break;

            case 'bake':
                number*=3;
                 break;

            case 'fillet':
                number*=0.8;
                break;
        
            default:
                break;
        }

        console.log(Math.round(number * 10) / 10);
        
    }
}

CookingByNumbers(['32', 'chop', 'chop', 'chop', 'chop', 'chop']);
CookingByNumbers(['9', 'dice', 'spice', 'chop', 'bake', 'fillet']);