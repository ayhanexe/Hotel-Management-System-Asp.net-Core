$(document).ready(function () {


    $(".tentac-star-selector .star-icon").on("mouseover", function () {
        const value = $(this).data("count");

        $(".tentac-star-selector .star-icon").removeClass("active")

        for (let i = 1; i <= value; i++) {
            $(`.tentac-star-selector .star-icon:nth-child(${i + 1})`).addClass("active");
        }
        $(".tentac-star-selector input[type=hidden]").attr("value", value);
    })
});