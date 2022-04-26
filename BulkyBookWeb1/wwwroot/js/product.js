var dataTable;
$(document).ready(function () {
    loadDataTable();
});
function loadDataTable() {
    dataTable = $('#tdlData').DataTable({
        "ajax": {
            "url":"/Admin/Product/GetAll"
        },
        "columns": [
            { "data": "title", "with": "15%" },
            { "data": "isbn", "with": "15%" },
            { "data": "price", "with": "15%" },
            { "data": "author", "with": "15%" }
           
        ]
    });
}