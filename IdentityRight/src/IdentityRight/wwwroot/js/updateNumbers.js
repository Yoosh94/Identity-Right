function collapseAll() {
    $("#mobiles").collapse("hide");
    $("#work").collapse("hide");
    $("#home").collapse("hide");
    $("#business").collapse("hide");

    $("#c-e").html('<a href="#" onclick="expandAll();">Expand All ( + )</a>');


}

function expandAll() {
    $("#mobiles").collapse("show");
    $("#work").collapse("show");
    $("#home").collapse("show");
    $("#business").collapse("show");

    $("#c-e").html('<a href="#" onclick="collapseAll();">Collapse All ( - )</a>');

}
