function RoadRadar(array) {
    let speedLimit = 0;
    let speed=array[0];
    let roadType= array[1];

    switch (roadType) {
        case 'motorway':
            speedLimit = 130;
            break;

        case 'interstate': speedLimit = 90;
            break;

        case 'city': speedLimit = 50;
            break;

        case 'residential': speedLimit = 20;
            break;
        default:
            break;
    }

    if (speed - speedLimit > 0) {
        GetSpeedMessage(speed-speedLimit);
    }

    function GetSpeedMessage(overspeed) {
        if (overspeed <= 20) {
            console.log('speeding');
        }
        else if (overspeed <= 40) {
        console.log('excessive speeding');
        }
        else {
            console.log('reckless driving');
        }
    }
}

RoadRadar([40, 'city']);
RoadRadar([21, 'residential']);
RoadRadar([120, 'interstate']);
RoadRadar([200, 'motorway']);
