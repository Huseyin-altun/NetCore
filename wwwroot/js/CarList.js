var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/cars/getall/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "model", "width": "20%" },
            { "data": "price", "width": "20%" },
            { "data": "popular", "width": "20%" },
            {
                "data": "carID",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/Cars/Upsert?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:80px;'>
                            Düzenle
                        </a>
                        &nbsp;
                        <a class='btn btn-danger text-white' style='cursor:pointer; width:80px;'
                            onclick=Delete('/Cars/Delete?id='+${data})>
                        Sil
                        </a>
                        </div>`;
                }, "width": "40%"
            }
        ],
        "language": {
            "emptyTable": "Veri Bulunamadı"
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Emin misin?",
        text: "Silindiğinde, kurtaramayacaksın",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}