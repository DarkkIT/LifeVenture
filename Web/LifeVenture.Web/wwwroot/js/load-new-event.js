let main = function () {
    let firstRegion = document.getElementById('region-0');
    firstRegion.addEventListener('change', loadMunicipality);

    let firstMunicipality = document.getElementById('municipality-0');
    firstMunicipality.addEventListener('change', loadSettlements);

    let locationBtn = document.getElementById('location-btn-0');
    locationBtn.addEventListener('click', createNewLocationFields);
}

let createNewLocationFields = function (event) {
    event.preventDefault();
    let btn = event.target;
    btn.style.display = 'none';
    let btnIdAsArray = btn.id.split('-');
    let btnId = btnIdAsArray[btnIdAsArray.length - 1];
    let nextNumber = parseInt(btnId) + 1;
    let removeLocationsBtn = document.getElementById(`remove-location-btn-${btnId}`);

    if (removeLocationsBtn) {
        removeLocationsBtn.style.display = 'none';
    }

    let newParentDiv = document.createElement('div');
    newParentDiv.id = `place-${nextNumber}`;

    let selectFiedsRow = createSelectFieldsRow(nextNumber);
    let textAreaRow = createTextAreaRow(nextNumber);

    newParentDiv.appendChild(selectFiedsRow);
    newParentDiv.appendChild(textAreaRow);

    let existingNode = document.getElementById(`place-${btnId}`);
    insertAfter(newParentDiv, existingNode);
}

let insertAfter = function (newNode, existingNode) {
    existingNode.after(newNode);
}

let createSelectFieldsRow = function (btnId) {
    let selectFieldsRow = document.createElement('div');
    selectFieldsRow.classList.add('row');
    selectFieldsRow.classList.add('new-event-element');

    let regionCol = createColumn('Област', `region-${btnId}`, `Locations[${btnId}].RegionId`);
    let regionSelect = regionCol.children[regionCol.children.length - 1];
    regionSelect.addEventListener('change', loadMunicipality);
    addValuesToSelect(regionSelect);

    let municipalityCol = createColumn('Община', `municipality-${btnId}`, `Locations[${btnId}].MunicipalityId`, true);
    let municipalitySelect = municipalityCol.children[municipalityCol.children.length - 1];
    municipalitySelect.addEventListener('change', loadSettlements);

    let settlementCol = createColumn('Населено място', `settlement-${btnId}`, `Locations[${btnId}].SettlementId`, true);

    selectFieldsRow.appendChild(regionCol);
    selectFieldsRow.appendChild(municipalityCol);
    selectFieldsRow.appendChild(settlementCol);

    return selectFieldsRow;
}

let addValuesToSelect = function (select) {
    let municipalitiesUrl = "/api/LocationsApi/GetRegions";
    getValuesForSelect(municipalitiesUrl, select);
}

let createTextAreaRow = function (btnId) {
    let row = document.createElement('div');
    row.classList.add('row');

    let col = createTextAreaColumn('Бележка', btnId);
    let addLocationsButton = createAddLocationsButton(btnId);
    let removeLocationsButton = createRemoveLocationsButton(btnId);

    col.appendChild(addLocationsButton);
    col.appendChild(removeLocationsButton);
    row.appendChild(col);

    return row;
}

let createTextAreaColumn = function (label, id) {
    let col = document.createElement('div');
    col.classList.add('col');
    col.classList.add('new-event-element');

    let labelField = document.createElement('label');
    labelField.textContent = label;

    let textArea = document.createElement('textarea');
    textArea.classList.add('form-control');
    textArea.classList.add('new-event-element');
    textArea.setAttribute('rows', '4');
    textArea.id = `address-note-${id}`;

    col.appendChild(labelField);
    col.appendChild(textArea);

    return col;
}

let createAddLocationsButton = function (id) {
    let button = document.createElement('input');
    button.id = `location-btn-${id}`;
    button.setAttribute('value', 'Добави локация');
    button.addEventListener('click', createNewLocationFields);
    return button;
}

let createRemoveLocationsButton = function (id) {
    let button = document.createElement('input');
    button.id = `remove-location-btn-${id}`;
    button.setAttribute('value', 'Премахни локация');
    button.addEventListener('click', removeLocationFields);
    return button;
}

let removeLocationFields = function (event) {
    event.preventDefault();
    let eventTarget = event.target;
    let eventTargetId = eventTarget.id;
    let splittedId = eventTargetId.split('-');
    let id = splittedId[splittedId.length - 1];
    let idAsNumber = parseInt(id);

    deleteLocationsElements(id);

    let lastId = idAsNumber - 1;
    showElement(`location-btn-${lastId}`);

    if (lastId > 1) {
        showElement(`remove-location-btn-${lastId}`);
    }
}

let showElement = function (id) {
    let btn = document.getElementById(id);
    btn.style.display = 'inline-block';
}

let deleteLocationsElements = function (id) {
    let elementToDelete = document.getElementById(`place-${id}`);
    elementToDelete.remove();
}

let createColumn = function (labelText, selectId, elementName, isDisabled) {
    let col = document.createElement('div');
    col.classList.add('col');

    let label = document.createElement('label');
    label.textContent = labelText;

    let select = document.createElement('select');
    select.id = selectId;
    select.setAttribute('name', elementName)
    select.classList.add('form-control');

    let defaultOption = document.createElement('option');
    defaultOption.value = '0';
    defaultOption.textContent = 'ИЗБЕРИ';

    select.appendChild(defaultOption);

    if (isDisabled) {
        select.disabled = true;
    }

    col.appendChild(label);
    col.appendChild(select);
    return col;
}

let loadMunicipality = function (event) {
    let select = event.target;
    let regionId = select.value;

    let splittedSelectId = select.id.split('-');
    let municipalitySelect = getSelect('municipality-' + splittedSelectId[1]);
    let settlementsSelect = getSelect('settlement-' + splittedSelectId[1]);

    if (regionId === '0') {
        municipalitySelect.disabled = true;
        settlementsSelect.disabled = true;
        return;
    }

    settlementsSelect.disabled = true;

    let municipalitiesUrl = "/api/LocationsApi/GetMunicipalities" + '?regionId=' + regionId;
    getValuesForSelect(municipalitiesUrl, municipalitySelect);
}

let loadSettlements = function (event) {
    let select = event.target;
    let municipalityId = select.value;

    let splittedSelectId = select.id.split('-');
    let settlementsSelect = getSelect('settlement-' + splittedSelectId[1]);

    if (municipalityId === '0') {
        settlementsSelect.disabled = true;
        return;
    }

    let settlementsUrl = "/api/LocationsApi/GetSettlements" + '?municipalityId=' + municipalityId;
    getValuesForSelect(settlementsUrl, settlementsSelect);
}

let getValuesForSelect = function (url, select) {
    let antiForgeryToken = document.querySelector('#antiForgeryForm input[name=__RequestVerificationToken]').value;
    let xhr = new XMLHttpRequest();
    xhr.open("GET", url, true);
    xhr.setRequestHeader('Content-Type', 'application/json');
    xhr.setRequestHeader('X-CSRF-TOKEN', antiForgeryToken);
    xhr.send();

    xhr.onreadystatechange = function () {
        if (this.status == 200 && this.responseText) {
            let responseObjects = JSON.parse(this.responseText);

            if (select.children.length == 1) {
                responseObjects.forEach(el => {

                    let option = document.createElement('option');
                    option.value = el.id;
                    option.innerText = el.name;
                    select.appendChild(option);
                    select.disabled = false;
                });
            }
        }
    };
}

let getSelect = function (id) {
    let select = document.getElementById(id);

    if (select.children.length > 1) {

        [...select.children].forEach(el => {
            if (el.value === '0') {
                return;
            }

            select.removeChild(el);
        });
    }

    return select;
}

main();