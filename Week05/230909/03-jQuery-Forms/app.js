// $("#city").on("change",function(){})
$("#city").change(function () {
    let selectedCity = $("#city :selected").text();
    let selectedCityValue = $("#city :selected").attr("value");
    //Value için başka alternatif var mı araştırın
    // let selectedCityValue = $("#city :selected").val();
    console.log(selectedCityValue);
    $("#message").text(`${selectedCity} şehrini seçtiniz. Plaka kodu: ${selectedCityValue}`);
})

$("#register-form").submit(function(e){
    e.preventDefault();
    $("#message").text("Kayıt işlemi başarıyla tamamlanmıştır")
})

$("#label-submit-button").click(function(){
    $("#register-form").submit();
})