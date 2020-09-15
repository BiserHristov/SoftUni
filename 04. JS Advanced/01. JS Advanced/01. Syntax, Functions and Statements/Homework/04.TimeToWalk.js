function TimeToWalk(steps, footprint, speed) {
    let distance = (steps * footprint) / 1000;

    let duration = distance / speed;
    let hours = '00';
    let minutes = '00';
    let seconds = '00';
    if (duration > 1) {
        hours = Math.floor(duration);
        duration -= hours;
    }
    else {
        duration *= 60;
        if (duration % 1 == 0) {
            minutes = duration;
        }
        else {
            minutes = Math.floor(duration);
            seconds = (duration % 1) * 60;
        }

    }

    if (distance >= 0.5) {
        let breaks =  Math.floor(distance / 0.5);
        if (breaks >= 60) {
            let breakHours = breaks / 60;
            if (breakHours % 1 != 0) {
                hours+= Math.floor(breakHours);
                minutes+=(breakHours % 1 )*60;
            }
            else{
                minutes+=(breakHours % 1 )*60;
            }
            
        }else{
            minutes+=breaks;
        }
    }

    console.log(`${hours}:${minutes}:${parseInt(Math.ceil(seconds))}`);
}

TimeToWalk(4000, 0.60, 5);
TimeToWalk(2564, 0.70, 5.5);
