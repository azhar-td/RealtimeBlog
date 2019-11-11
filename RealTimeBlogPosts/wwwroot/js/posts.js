"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/postsHub").build();

connection.on("NewPostCreated", function (post) {
    signalRConnection(1);
    $.toaster({ priority: 'success', title: 'New Post', message: '<strong>Title:</strong>' +post.title+' and <strong>Author:</strong>'+post.author });
});
connection.start().then(function () {
    //document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

$(document).ready(function () {
    var url = window.location.href;
    var page = url.substring(url.lastIndexOf('/') + 1);
    if (page != null && page != undefined && page != "") {
        signalRConnection(page);
    }
    else {
        signalRConnection(1);//Default page-1
    }
});


function signalRConnection(page) {
    $.ajax({
        url: '/Home/PostList/',
        dataType: "html",
        type: "Get",
        data: { "page": page }
    }).done(function (response) {
        //alert('test');
        $("#postListsDiv").html(response);
    });
}