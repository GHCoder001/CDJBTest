
$(document).ready(function () {
    $("#Generate").on("click", GenerateProductReview);
});


function GenerateProductReview() {
    $.ajax({
        dataType: "html",
        url: "/Home/GenerateProductReview",
        type: 'Get',
        success: function (data) {
            $('#ProductReviewDetails').html(data);
        },
        error: function (xhr) {
            alert("Error getting review details")
        }
    });
}



