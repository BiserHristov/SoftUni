const elements = {
    info: document.querySelector('.notification.infoBox'),
    error: document.querySelector('.notification.errorBox'),
    loading: document.querySelector('.notification.loadingBox')
};

elements.info.addEventListener('click', hideInfo);
elements.error.addEventListener('click', hideError);
elements.loading.addEventListener('click', hideLoading);


export function showInfo(message) {
    elements.info.textContent = message;
    elements.info.style.display = 'block';

    setTimeout(hideInfo, 3000);
}

export function showError(message) {
    elements.error.textContent = message;
    elements.error.style.display = 'block';
    setTimeout(hideError, 3000);
}
export function showLoading() {
    elements.loading.style.display = 'block';
}
let requests = 0;

export function beginRequest() {
    requests++;
    elements.loading.style.display = 'block';
}

export function endRequest() {
    requests--;
    if (requests === 0) {
        elements.loading.style.display = 'none';
    }
}

function hideInfo() {
    elements.info.style.display = 'none';
}

function hideError() {
    elements.error.style.display = 'none';
}
export function hideLoading() {
    elements.loading.style.display = 'none';
}