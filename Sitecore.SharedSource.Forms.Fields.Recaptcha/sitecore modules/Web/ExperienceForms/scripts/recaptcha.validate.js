$.validator.setDefaults({ ignore: ":hidden:not(.fxt-captcha)" });

/**
 * Google Recaptcha
 */
var reCaptchaArray = [];
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
	$('input[type="submit"]').click(function(){
	 grecaptcha.execute();
	 if(!$('.fxt-captcha').val())
	 {
		 return false;
	 }
	 });
};