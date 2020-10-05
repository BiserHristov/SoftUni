function attachEventsListeners() {

    let daysInput = document.querySelector('#days');
    let hoursInput = document.querySelector('#hours');
    let minutesInput = document.querySelector('#minutes');
    let secondsInput = document.querySelector('#seconds');

    document.querySelector('#daysBtn').addEventListener('click', ()=>{convert(daysInput.value * 24 * 60 * 60)});
    document.querySelector('#hoursBtn').addEventListener('click', ()=>{convert(hoursInput.value * 60 * 60)});
    document.querySelector('#minutesBtn').addEventListener('click', ()=>{convert(minutesInput.value * 60)});
    document.querySelector('#secondsBtn').addEventListener('click', ()=>{convert(secondsInput.value)});





    function convert(seconds) {
        daysInput.value = seconds / (24 * 60 * 60);
        hoursInput.value = seconds / (60 * 60);
        minutesInput.value = seconds / 60;
        secondsInput.value = seconds;
    }
}