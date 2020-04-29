//var connection =
//    new signalR.HubConnectionBuilder()
//        .withUrl("/hub/chat")
//        .build();

//connection.on("NewMessage",
//    function (message) {
//        var chatInfo = `<div>[${message.user}] ${escapeHtml(message.text)}</div>`;
//        chatInfo = `<div class="sent_msg">
//                        <h4 class="justify-content-lg-end">${message.user}</h4>
//                        <p>
//                            ${escapeHtml(message.text)}
//                        </p>
//                        <span class="time_date"> 11:01 AM    |    June 9</span>
//                    </div>`
//        $("#messagesList").append(chatInfo);
//    });

//connection.on("ConnectedUsers",
//    function (connectedUsers) {
//        $("#user-info-div").html('');
//        connectedUsers.forEach(function (user) {
//            var userInfoDiv = 
//                `<a href="${user.profileUrl}">
//                    <div class="chat_list active_chat" id="user-info-div">
//                        <div class="chat_people">
//                            <div class="chat_img"> <img src="${user.profilePhotoUrl}" alt="sunil"> </div>
//                            <div class="chat_ib">
//                                <h5>${user.username}</h5>
//                            </div>
//                        </div>
//                    </div>
//                 </a>`
//            $("#user-info-div").append(userInfoDiv);
//        })
//    });

//connection.start().catch(function (err) {
//    return console.error(err.toString());
//});

//$("#sendButton").click(sendMessage);

//$("#messageInput").on('keydown', function (e) {
//    if (e.key == 'Enter') {
//        sendMessage();
//    }
//});

//$("#get-users").click(getAllConnectedUsers)

//function sendMessage() {
//    var message = $("#messageInput").val();
//    $("#messageInput").val('');
//    connection.invoke("Send", message);
//}

//function getAllConnectedUsers() {
//    connection.invoke("GetAllActiveConnections");
//}

//function escapeHtml(unsafe) {
//    return unsafe
//        .replace(/&/g, "&amp;")
//        .replace(/</g, "&lt;")
//        .replace(/>/g, "&gt;")
//        .replace(/"/g, "&quot;")
//        .replace(/'/g, "&#039;");
//}