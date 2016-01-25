function StuffSelection_Proxy() { }

StuffSelection_Proxy.GetStuffListHttpGet =
           function (successCallback, failureCallback) {
               $.ajax({
                   type: "GET",
                   contentType: "application/json; charset=utf-8",
                   url: "Play.aspx/GetGameServiceHttpGet",
                   success: function (data) { successCallback(data); },
                   error: function (data) { failureCallback(data); }
               });
           }