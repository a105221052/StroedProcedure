function Search() {    
    let area = $('#location').find(":selected").text();
    $.ajax({
        type: "POST",
        url: '/Home/Area_Amount',
        data: { "area": area },
    }).done(function (result) {
        $("#resultInfo").css("display", "block")
        $("#amount").text(result);
    });
}