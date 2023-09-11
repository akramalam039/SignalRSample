"use strict"
var cloakCounter = document.getElementById("cloakCounter");
var stoneCounter = document.getElementById("stoneCounter");
var wandCounter = document.getElementById("wandCounter");
//create connection
var connectionDealthyHallow = new signalR.HubConnectionBuilder().withUrl("/hubs/dealthyhallows").build();

//connect to method that hub invokes aka receive notification from hub
connectionDealthyHallow.on("updateDealthyHallowCount", (cloak,stone,wand) =>//value is represting totalviews
{
    
    cloakCounter.innerText = cloak.toString();
    stoneCounter.innerText = stone.toString();
    wandCounter.innerText = wand.toString();

});
//start connection
function fullFill() {
    //if connection made successfully
    connectionDealthyHallow.invoke("GetRaceStatus").then((racecounter) => {
        cloakCounter.innerText = racecounter.cloak.toString();
        stoneCounter.innerText = racecounter.stone.toString();
        wandCounter.innerText = racecounter.wand.toString();
    });
    console.log('connection to user hub successfull');
}
function rejected() {
    //if connection not made succesfully

}
connectionDealthyHallow.start().then(fullFill, rejected);