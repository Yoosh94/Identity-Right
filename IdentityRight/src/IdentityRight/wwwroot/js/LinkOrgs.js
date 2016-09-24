
//Function to select all options before submitting
$('#submitLinks').click(function () {
    $('#leftSelect option').prop('selected', true);
});


//Function that switches orgs between linked and unlinked
$().ready(function () {
    $('#addOrg').click(function () {

        return !$('#rightSelect option:selected').remove().appendTo('#leftSelect');
    });
    $('#removeOrg').click(function () {

        return !$('#leftSelect option:selected').remove().appendTo('#rightSelect');
    });
});

//Function which will allow user to search for an organisation
function searchOrganisation() {
    //Get the value of what the user has searched
    var searchTerm = document.getElementById("srch-term").value;
    //Foreach option in the multiselect list check if the text contains a substring of what the user has searched
    $('#rightSelect option').each(function () {
        //If there are no matches hide the option
        if ($(this).text().toLowerCase().indexOf(searchTerm.toLowerCase()) < 0) {
            $(this).hide();
        }
        //If the substring exists make sure its visible
        else {
            $(this).show();
        }           
    })
}
var url = '@Url.Action("NewNumberInput", "Identity")';





