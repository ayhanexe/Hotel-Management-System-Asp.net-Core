$(document).ready(() => {
    $('.datepicker-here').datepicker({
        language: 'tr',
        minDate: new Date()
    })
    $("#category-list-search-input").on("keyup", function () {
        var value = $(this).val();

        $.ajax({
            type: "POST",
            url: "Category/Search",
            data: {
                searchValue: value
            },
            success: function (res) {
                $("#category-body").empty();
                $("#category-body").append(res);
            }
        })
    });

    $(".delete-category-button").on("click", function () {
        const row = $(this).closest(".category-row")
        const id = $(row).data("category-id");

        if (Number.isFinite(id)) {
            Swal.fire({
                title: 'Are you sure?',
                text: "You won't be able to revert this!",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Yes, delete it!'
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        type: "POST",
                        url: `Category/Delete/${id}`,
                        success: function (res) {
                            $(row).remove();
                            Swal.fire(
                                'Deleted!',
                                'Your file has been deleted.',
                                'success'
                            )
                        }
                    })
                }
            })
        }

    })

    $(".delete-header-item").on("click", async function () {
        const id = $(this).data("header-item-id")
        var row = $(this).parents("tr");


        await swal.fire({
            icon: "error",
            title: "Are you sure?",
            confirmButtonText: 'Delete',
            showCancelButton: true,
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: `${window.location.href}/DeleteHeaderItem/${id}`,
                    method: "POST",
                    success: async function (response) {
                        $(row).remove();
                        await swal.fire({
                            icon: "success",
                            title: "Successfully Deleted!"
                        })
                    }
                })
            }
        })
    })
})