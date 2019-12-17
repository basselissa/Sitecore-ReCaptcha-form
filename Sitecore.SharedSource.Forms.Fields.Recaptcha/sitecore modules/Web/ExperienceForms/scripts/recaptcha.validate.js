$.validator.setDefaults({ ignore: ":hidden:not(.fxt-captcha)" });

/**
 * Google Recaptcha
 */
if (reCaptchaArray === undefined) {
    var reCaptchaArray = [];
}
$.validator.unobtrusive.adapters.add("recaptcha", function (options) {
    options.rules["recaptcha"] = true;
    if (options.message) {
        options.messages["recaptcha"] = options.message;
    }
});

$.validator.addMethod("recaptcha", function (value, element, exclude) {
	return true;
});
var recaptchasRendered = false;
var loadReCaptchas = function () {
    if (recaptchasRendered) {
        return;
    }
    recaptchasRendered = true;
    for (var i = 0; i < reCaptchaArray.length; i++) {
        reCaptchaArray[i]();
    }
    //this code will not work with mulitple recaptcha in the same page
    /* 
	$('input[type="submit"]').click(function(){
	 grecaptcha.execute();
	 if(!$('.fxt-captcha').val())
	 {
		 return false;
	 }
	 });
     */
};