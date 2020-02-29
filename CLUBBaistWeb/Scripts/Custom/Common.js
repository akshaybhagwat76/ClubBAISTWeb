$(document).ready(function () {
    $(".curLanguage").on("change", function () {
        ajaxFunc("/Home/ChangeRegion", { lang: $(this).val() }, function (d) {
            regionInfo = {
                userLang: d.language,
                curSymbol: d.curSymbol,
                curPrefix: d.curPrefix,
                curSuffix: d.curSuffix,
                name: d.name,
                sal_min: d.sal_min,
                sal_max: d.sal_max,
                sal_increment: d.sal_increment,
                daily_rate_min: d.daily_rate_min,
                daily_rate_max: d.daily_rate_max,
                daily_rate_increment: d.daily_rate_increment,
            };
            $("body").trigger("region_changed");
        });
    });
});
function isEmail(email) {
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(email);
}
function StartProcess() {
    $(".preloader").fadeIn("slow");
}
function StopProcess() {
    $(".preloader").fadeOut("slow");
}
function bytesToSize(bytes) {
    if (bytes == 0) return '0 KB';
    var iSize = (bytes / 1024);
    return parseInt(Math.round(iSize * 100) / 100);
};
function funToastr(status, msg) {
    toastr.options = {
        "closeButton": true,
        "debug": false,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "onclick": null,
        "showDuration": "400",
        "hideDuration": "1000",
        "timeOut": "7000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
    if (status) {
        toastr.success('', msg)
    }
    else {
        toastr.error('', msg)
    }
}
$.fn.serializeFormToObject = function () {
    //serialize to array
    var data = $(this).serializeArray();

    //add also disabled items
    $(':disabled[name]', this)
        .each(function () {
            data.push({ name: this.name, value: $(this).val() });
        });

    //map to object
    var obj = {};
    data.map(function (x) { obj[x.name] = x.value; });

    return obj;
};

function PasswordChecker(password) {
    if (password != "") {
        if (password.length < 8)
            return "Password must contain at least eight characters.";

        re = /[A-Z]/;
        if (!re.test(password))
            return "Password must contain at least one uppercase letter.";

        re = /[!@#$%\^&*(){}[\]<>?/|\-]/;
        if (!re.test(password))
            return "Password must contain at least one special character.";
    }
    else {
        return "Password is required field.";
    }
    return "success";
}
function ajaxFunc(url, data, callback, options) {
    let defaults = {
        type: "POST",
        url: url,
        data: data,
        dataType: 'json',
        beforeSend: x => {
            StartProcess();
        }
    };
    if (data instanceof FormData) {
        defaults.contentType = false;
        defaults.processData = false;
    }
    if (options) {
        defaults = $.extend({}, defaults, options);
    }
    return $.ajax(defaults)
        .done(data => {
            if (data.status == "Fail") {
                $("#lblError").addClass("error").text(data.error).show();
            } else {
                if (typeof callback === "function") {
                    callback(data.data);
                }
            }
        })
        .always(x => {
            StopProcess();
        });
}

function getFormData(obj) {
    let convertToFormData = function (prefix, obj, formData) {
        prefix = prefix || "";
        if (Array.isArray(obj)) {
            obj.forEach((x, i) => {
                convertToFormData(prefix + "[" + i + "]", x, formData);
            });
        } else if (typeof obj === "object") {
            for (let p in obj) {
                let _prefix = prefix == "" ? p : prefix + "[" + p + "]";
                if (Array.isArray(obj[p])) {
                    obj[p].forEach((x, i) => {
                        convertToFormData(_prefix + "[" + i + "]", x, formData);
                    });
                } else if (typeof obj[p] === "object") {
                    convertToFormData(_prefix, obj[p], formData);
                } else {
                    formData.append(_prefix, obj[p]);
                }
            }
        } else {
            formData.append(prefix, obj);
        }
    }
    var formData = new FormData();
    convertToFormData("", obj, formData);
    return formData;
}

function lorem(count) {
    let words = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.".split(/ /g);
    while (words.length < count) {
        words = words.concat(words);
    }
    return (!count ? words : words.slice(0, count)).join(" ");
}

function random(min = 0, max = 100) {
    return Math.floor((Math.random() * (max - min)) + max);
}