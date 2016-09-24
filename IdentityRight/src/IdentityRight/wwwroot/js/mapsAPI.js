var input = document.getElementById('address');
var componentForm = {
    subpremise: 'short_name',
    street_number: 'short_name',
    route: 'long_name',
    locality: 'long_name',
    administrative_area_level_1: 'short_name',
    country: 'long_name',
    postal_code: 'short_name',
};

var fixedComponentForm = {
    subpremise: "unitNumber",
    street_number: "streetNumber",
    route: "streetName",
    locality:"suburb",
    administrative_area_level_1:"state",
    country: "countryName",
    postal_code:"postcode",
};

var options = {
    
    componentRestrictions: { country: 'au' }
};
autocomplete = new google.maps.places.Autocomplete(input, options);
// When the user selects an address from the dropdown, populate the address
// fields in the form.
autocomplete.addListener('place_changed', fillInAddress);

function fillInAddress() {
    // Get the place details from the autocomplete object.
    var place = autocomplete.getPlace();

    for (var component in fixedComponentForm) {
        document.getElementById(fixedComponentForm[component]).value = '';
        document.getElementById(fixedComponentForm[component]).readOnly = true;
        document.getElementById(fixedComponentForm[component]).disabled = false;
    }

    // Get each component of the address from the place details
    // and fill the corresponding field on the form.
    for (var i = 0; i < place.address_components.length; i++) {
        var addressType = place.address_components[i].types[0];
        if (componentForm[addressType]) {
            var val = place.address_components[i][componentForm[addressType]];
            document.getElementById(fixedComponentForm[addressType]).value = val;
        }
    }
}