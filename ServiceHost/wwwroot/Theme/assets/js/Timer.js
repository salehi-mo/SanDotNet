var minutes;
var seconds;
var set_inteval;
function otp_timer() {
    seconds -= 1;
    
    document.getElementById('seconds').innerHTML = seconds;
    document.getElementById('minutes').innerHTML = minutes;

    if (seconds == 0) {
        if (minutes > 0) {
            seconds = 60;
            minutes -= 1;
        } else {
            minutes = 0;
            document.getElementById('minutes').innerHTML = minutes;
            clearInterval(set_inteval);
            minutes = 0;
            seconds = 0;
            document.getElementById('seconds').innerHTML = '00';
            document.getElementById('minutes').innerHTML = '0';
            document.getElementById('ReVerifyCode').innerText = 'دریافت کد';
            document.getElementById('ReVerifyCode').enable = "true";
        }
    }
}
//function startTimer(min,sec) {
//    if ((min === '0') && (sec === '00'))
//    {
//        minutes = 1;
//        seconds = 60;
//    }
//    else
//    {
//        minutes = min;
//        seconds = sec;
//    }
    
//    clearInterval(set_inteval);
//    debugger;
//    document.getElementById('seconds').innerHTML = seconds;
//    document.getElementById('minutes').innerHTML = minutes;
//    set_inteval = setInterval('otp_timer()', 1000);
//}

function startTimer() {
   
    minutes = 1;
    seconds = 60;

    clearInterval(set_inteval);
    
    document.getElementById('seconds').innerHTML = seconds;
    document.getElementById('minutes').innerHTML = minutes;
    set_inteval = setInterval('otp_timer()', 1000);
    if ((minutes === '0')) {
        document.getElementById('ReVerifyCode').innerText = 'دریافت کد';
        document.getElementById('ReVerifyCode').enable = "true";
    }
}