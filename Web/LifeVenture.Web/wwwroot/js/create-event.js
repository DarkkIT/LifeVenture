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
    let categoryEl = form.querySelector('#CategoryId');
    let isUrgentEl = form.querySelector('#IsUrgent');
    let titleEl = form.querySelector('#Title');
    let descriptionEl = form.querySelector('#Description');
    let startDateEl = form.querySelector('#start');
    let endDateEl = form.querySelector('#end');
    let emailEl = form.querySelector('#Email');
    let phoneCodeEl = form.querySelector('#Phone_CodeId');
    let phoneNumberEl = form.querySelector('#Phone_Number');

    let startDate = getDate(startDateEl.value);
    let endDate = getDate(endDateEl.value);

    let data = {
        CategoryId: categoryEl.value,
        IsUrgent: isUrgentEl.checked,
        Title: titleEl.value,
        Description: descriptionEl.value,
        StartDate: startDate,
        EndDate: endDate,
        //Locations: [{ RegionId: 1, MunicipalityId: 1, SettlementId: 1 }],
        Email: emailEl.value,
        Phone: {
            CodeId: phoneCodeEl.value,
            Number: phoneNumberEl.value,
        },
        //Image: null
    }

    let url = '/Events/Create'
    let antiForgeryToken = document.querySelector('#antiForgeryForm input[name=__RequestVerificationToken]').value;
    let xhr = new XMLHttpRequest();
    xhr.open("POST", url, true);
    xhr.setRequestHeader('Content-Type', 'application/json');
    xhr.setRequestHeader('X-CSRF-TOKEN', antiForgeryToken);
    xhr.send(JSON.stringify(data));

    xhr.onreadystatechange = function () {
        debugger;
        if (this.status == 200 && this.responseText) {
        }
    };
}

let getDate = function(dateAsString) {
    let dateParts = dateAsString.split('-');
    let dateObject = new Date(+dateParts[2], dateParts[1] - 1, +dateParts[0]);
    return dateObject;
}

addEventListener();

