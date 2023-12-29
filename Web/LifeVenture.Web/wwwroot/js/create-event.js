const form = document.getElementById("events-form");

let addEventListener = function () {
    debugger;
    let submitBtn = document.getElementById('submit-btn');
    submitBtn.addEventListener('click', createEvent);
}

let createEvent = function (event) {
    debugger;
    event.preventDefault();
    sendData();
}

let sendData = function () {
    debugger;
    let formData = new FormData(form);
    let allData = formData.values();
    let allKeys = formData.keys();

    //for (const key of allKeys) {
    //    console.log(key);
    //}

    //for (const value of allData) {
    //    console.log(value);
    //}

    let antiForgeryToken = document.querySelector('#antiForgeryForm input[name=__RequestVerificationToken]').value;
    let xhr = new XMLHttpRequest();
    xhr.open("POST", url, true);
    xhr.setRequestHeader('Content-Type', 'application/json');
    xhr.setRequestHeader('X-CSRF-TOKEN', antiForgeryToken);
    xhr.send(formData);

    xhr.onreadystatechange = function () {
        if (this.status == 200 && this.responseText) {
        }
    };
}

addEventListener();

