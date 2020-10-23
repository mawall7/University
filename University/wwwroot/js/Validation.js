$.validator.addMethod('streetnr', function (value, element, params) {
    let last = value.split('').pop();
    let res = parseInt(last);
    return isNaN(res) ? false : true;
});

$.validator.unobtrusive.adapters.addBool('streetnr');