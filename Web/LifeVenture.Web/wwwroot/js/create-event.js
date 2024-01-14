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
    //let formData = new FormData();
    //formData.append('CategoryId',);
    //formData.append('IsUrgent',);
    //formData.append('Title',);
    //formData.append('Description',);
    //formData.append('StartDate',);
    //formData.append('EndDate',);
    //formData.append('EndDate',); region - 1
    let categoryEl = form.querySelector('#CategoryId');
    let isUrgentEl = form.querySelector('#IsUrgent');
    let titleEl = form.querySelector('#Title');
    let descriptionEl = form.querySelector('#Description');
    let startDateEl = form.querySelector('#start');
    let endDateEl = form.querySelector('#end');
    let emailEl = form.querySelector('#Email');
    let phoneCodeEl = form.querySelector('#Phone_CodeId');
    let phoneNumberEl = form.querySelector('#Phone_Number');

    let data = {
        CategoryId: categoryEl.value,
        IsUrgent: isUrgentEl.value,
        Title: titleEl.value,
        Descrption: descriptionEl.value,
        StartDate: startDateEl.value,
        EndDate: endDateEl.value,
        Locations: [{ RegionId: 1, MunicipalityId: 1, SettlementId: 1}],
        Email: emailEl.value,
        Phone: {
            CodeId: phoneCodeEl.value,
            Number: phoneNumberEl.value,
        },
        Image: null
    }

    let url = '/Events/Create'
    let antiForgeryToken = document.querySelector('#antiForgeryForm input[name=__RequestVerificationToken]').value;
    let xhr = new XMLHttpRequest();
    xhr.open("POST", url, true);
    xhr.setRequestHeader('Content-Type', 'application/json');
    xhr.setRequestHeader('X-CSRF-TOKEN', antiForgeryToken);
    xhr.send(JSON.stringify(data));

    xhr.onreadystatechange = function () {
        if (this.status == 200 && this.responseText) {
        }
    };
}

addEventListener();

