var isBusy = false;
var input;
var label;

$(document).ready(function () {
    
    input = $("#Scripture");
    label = $("#Label")

    $('span.Btn').mouseover(function (e) {
       $(e.target).css('color', 'black')
    });

    $('span.Btn').mouseout(function (e) {
        $(e.target).css('color', 'gray')
    });
});


function Push() {

    if (isBusy == true) { return false; }
    if (input.val() == "" || input.val() == null) { label.text("Сначала нужно ввести строку"); return false; }
    isBusy = true;
    label.text("Соединение с базой данных")
    $.ajax({
        url: '/api/values/',
        type: 'POST',
        data: JSON.stringify(input.val()),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
           
            label.text("Добавлена строка " + '"' + input.val() + '"')
            input.val("");
            input.focus();
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        },
        complete: function () {
            isBusy = false;
           // alert("success")
        }
    });
}


function Pop() {
    if (isBusy == true) { return false; }
    isBusy = true;
    label.text("Соединение с базой данных")
    $.ajax({
        url: '/api/values',
        type: 'DELETE',
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            input.val('')
            if (data != null) {
                label.text("Извлечение последней строки: " + '"' + data + '"');
            }
            else {
                label.text("База пуста");
            }
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        },
        complete: function () {
            isBusy = false;
            
        }
    });


    
}

function Peek() {
    if (isBusy == true) { return false; }
    isBusy = true;
    label.text("Соединение с базой данных")
    $.ajax({
        url: '/api/values',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            
            input.val('')
            if (data != null) {
                label.text('Просмотр последнего элемента:' + '"' + data + '"')
            }
            else {
                label.text("База пуста");
            }
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        },
        complete: function () {
            isBusy = false;
        }
    });
}




function GetSize() {
    if (isBusy == true) { return false; }
    isBusy = true;
    label.text("Соединение с базой данных")
    $.ajax({
        url: '/api/values/true',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            label.text('Всего строк: ' + data)
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        },
        complete: function () {
            isBusy = false;
        }
    });
}

