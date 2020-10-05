function encodeAndDecodeMessages() {
    document.querySelectorAll('button')[0].addEventListener('click', (e) => {
                                                                           //Don`t works in Judge             
        let messageElement = document.querySelectorAll('textarea')[0]; //e.target.previousElementSibling;
        let codedMsg = '';
        for (let i = 0; i < messageElement.value.length; i++) {
            let index = messageElement.value[i].charCodeAt(0);

            codedMsg += String.fromCharCode(index + 1);
        }

        document.querySelectorAll('textarea')[1].value = codedMsg;
        document.querySelectorAll('textarea')[0].value = '';

    })

    document.querySelectorAll('button')[1].addEventListener('click', (e) => {
                                                                           //Don`t works in Judge             
        let messageElement = document.querySelectorAll('textarea')[1]; //e.target.previousElementSibling;
        let decodedMsg = '';
        for (let i = 0; i < messageElement.value.length; i++) {
            let index = messageElement.value[i].charCodeAt(0);

            decodedMsg += String.fromCharCode(index - 1);
        }

        document.querySelectorAll('textarea')[1].value = decodedMsg

    })
}