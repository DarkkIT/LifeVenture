let main = function () {
    let firstRegion = document.getElementById('region-1');
    firstRegion.addEventListener('change', loadMunicipality);

    let firstMunicipality = document.getElementById('municipality-1');
    firstMunicipality.addEventListener('change', loadSettlements);
}

let loadMunicipality = function (event) {
    let select = event.target;
    let regionId = select.value;
    
    let splittedSelectId = select.id.split('-');
    let municipalitySelect = getSelect('municipality-' + splittedSelectId[1]);
    let settlementsSelect = getSelect('settlements-' + splittedSelectId[1]);

    if (regionId === '0') {
        municipalitySelect.disabled = true;
        settlementsSelect.disabled = true;
        return;
    }

    let municipalitiesUrl = "/api/LocationsApi/GetMunicipalities" + '?regionId=' + regionId;
    getValuesForSelect(municipalitiesUrl, municipalitySelect);
}

let loadSettlements = function (event) {
    let select = event.target;
    let municipalityId = select.value;

    let splittedSelectId = select.id.split('-');
    let settlementsSelect = getSelect('settlements-' + splittedSelectId[1]);

    if (municipalityId === '0') {
        settlementsSelect.disabled = true;
        return;
    }

    let settlementsUrl = "/api/LocationsApi/GetSettlements" + '?municipalityId=' + municipalityId;
    getValuesForSelect(settlementsUrl, settlementsSelect);
}

let getValuesForSelect = function (url, select) {
    var antiForgeryToken = document.querySelector('#antiForgeryForm input[name=__RequestVerificationToken]').value;
    var xhr = new XMLHttpRequest();
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