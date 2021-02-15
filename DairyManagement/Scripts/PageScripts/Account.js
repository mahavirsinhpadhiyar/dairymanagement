var oldStock = 0;
var todayMilkValue = 0;
var totalPurchase = 0;
var totalSell = 0;
var totalSP = 0;
var realStock = 0;
var OldStockReStore;

$("#ConsiderOldStock").on("change", function () {

    if ($(this).prop("checked") == false) {
        OldStockReStore = $("#OldStock").val();
        $("#OldStock").val(0.00);
    } else {
        $("#OldStock").val(OldStockReStore);
    }
    Calculate();
})

function isCharNumber(c) {
    return (c >= '0' && c <= '9') ||
        (c >= '10' && c <= '99') ||
        (c >= '100' && c <= '999');
}

function Calculate() {

    oldStock = 0;
    todayMilkValue = 0;
    totalPurchase = 0;
    totalSell = 0;
    totalSP = 0;
    realStock = 0;

    if ($("#TodayMilk").val().trim() != null) {
        oldStock = parseFloat($("#OldStock").val());
        todayMilkValue = parseFloat($("#TodayMilk").val().trim());
        totalPurchase = totalPurchase + todayMilkValue + oldStock;

        for (var j = 1; j <= i; j++) {
            if ($("#SPValue" + j) != undefined && isCharNumber($("#SPValue" + j).val())) {
                totalSP += parseFloat($("#SPValue" + j).val());
            }
        }

        totalPurchase += totalSP;
        $("#TotalPurchase").val(parseFloat(totalPurchase).toFixed(3));

        totalSell = parseFloat($("#TotalSell").val());
        $("#AvailableStock").val(parseFloat(totalPurchase - totalSell).toFixed(3));

        realStock = parseFloat($("#RealStock").val());

        $("#StockDifference").val(parseFloat(realStock - (totalPurchase - totalSell)).toFixed(3));
    }
}

function RemoveSP(objToRemove) {
    $("." + objToRemove).remove();
    Calculate();
}

$(function () {
    $('.toast').toast('show');
    $(".datepicker").datepicker();
    $(".datepicker").datepicker("option", "dateFormat", "dd/mm/yy");
    //$(".datepicker").datepicker("setDate", new Date());
    //$(".datepicker").datepicker("timeFormat", "hh:mm tt");
    //$("#accountForm").validate().valid();

    $('#btnAddSP').on('click', function () {
        $.ajax({
            url: '/Accounts/partialAddSP/',
            data: { i: i },
            success: function (data) {
                $("#divPartialAddSP").append(data);
                i++;
                //find the newly added row to bind click event to new img
                $("#divPartialAddSP tr").last().find("img").click(
                    function () {
                        //  $(this).parent().prev().find("input").val($(this).attr("id"));
                        $(this).parent().prev().find("input").attr("id", $(this).attr("id"));
                    }
                )

            }
        })
    })
})

//Calculate();