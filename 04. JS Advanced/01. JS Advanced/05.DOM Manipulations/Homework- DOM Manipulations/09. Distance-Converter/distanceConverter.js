function attachEventsListeners() {
    document.querySelector('#convert').addEventListener('click', e => {

        let inputElement = document.querySelector('#inputDistance');
        let inputDataInMeters = Number(inputElement.value);
        let inputSel = document.querySelector('#inputUnits');
        let inputMetric = inputSel.options[inputSel.selectedIndex].value;
        switch (inputMetric) {
            case 'km': inputDataInMeters *= 1000;
                break;
            case 'cm': inputDataInMeters *= 0.01;
                break;
            case 'mm': inputDataInMeters *= 0.001;
                break;
            case 'mi': inputDataInMeters *= 1609.34;
                break;
            case 'yrd': inputDataInMeters *= 0.9144;
                break;
            case 'ft': inputDataInMeters *= 0.3048;
                break;
            case 'in': inputDataInMeters *= 0.0254;
                break;
            default:
                break;
        }

        let outputSel = document.querySelector('#outputUnits');
        let outputMetric = outputSel.options[outputSel.selectedIndex].value;
        let outputData = inputDataInMeters;

        switch (outputMetric) {
            case 'km': outputData = inputDataInMeters / 1000;
                break;
            case 'cm': outputData = inputDataInMeters / 0.01;
                break;
            case 'mm': outputData = inputDataInMeters / 0.001;
                break;
            case 'mi': outputData = inputDataInMeters / 1609.34;
                break;
            case 'yrd': outputData = inputDataInMeters / 0.9144;
                break;
            case 'ft': outputData = inputDataInMeters / 0.3048;
                break;
            case 'in': outputData = inputDataInMeters / 0.0254;
                break;
            default:
                break;
        }

        let resultElement=document.querySelector('#outputDistance');
        resultElement.removeAttribute('disabled');
        resultElement.value=outputData;
    })
}