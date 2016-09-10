
$().ready(function () {
    $('#addOrg').click(function () {

        return !$('#rightSelect option:selected').remove().appendTo('#leftSelect');
    });
    $('#removeOrg').click(function () {

        return !$('#leftSelect option:selected').remove().appendTo('#rightSelect');
    });
});


function sendUpdate() {

    var leftWindow = document.getElementById('leftSelect');


    orgs = [];
    $('#leftSelect option').each(function () {
        orgs.push($(this).val())
    });


    /*for(var i = 0; i < orgs.length; i++)
    {
        alert(orgs[i]);
    }*/

    
    $.ajax({
        url: 'Identity/SetLinks',
        type: 'POST',
        data: JSON.stringify(orgs),
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        error: function (xhr) {
            alert('Error: ' + xhr.statusText);
        },
        success: function (result) {
            CheckIfInvoiceFound(result);
        },
        async: true,
        processData: false
    });
}