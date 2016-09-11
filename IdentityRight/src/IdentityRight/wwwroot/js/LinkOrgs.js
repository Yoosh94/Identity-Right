
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


