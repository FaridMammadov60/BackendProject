

//search
$(document).on("keyup", "#input-search-f", function () {
    
    let inputValue = $(this).val();
    console.log(inputValue);
    $("#searchList li").slice(1).remove();
    $("#searchList").html();
    $.ajax({
        url: "home/searchProduct?search=" + inputValue,
        method: "get",
        success: function (res) {
            console.log(res);
            $("#searchList").append(res);
           
        }
    })
});