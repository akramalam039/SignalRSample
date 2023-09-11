"use strict"
//create connection
var connectionUserCount = new signalR.HubConnectionBuilder().withUrl("/hubs/userCount", signalR.HttpTransportType.WebSockets).build();

//connect to method that hub invokes aka receive notification from hub
connectionUserCount.on("updateTotalViews", (TotalViews) =>//value is represting totalviews
{
    var newCountSpan = document.getElementById("totalViewsCounter");
    newCountSpan.innerText = TotalViews.toString();

});

connectionUserCount.on("updateTotalUser", (TotallUsers) => {
    var newUser = document.getElementById('activeUserCount');
    newUser.innerText = TotallUsers.toString();
})
//invoke hub method aka send notification to hub
function newWindowLoadedOnClient() {
    connectionUserCount.send("NewWindowLoaded");//UserHub Class Method name to invoke that method
}


//start connection
function fullFill() {
    //if connection made successfully
    newWindowLoadedOnClient();
    console.log('connection to user hub successfull');
}
function rejected() {
    //if connection not made succesfully
    
}


connectionUserCount.start().then(fullFill, rejected);