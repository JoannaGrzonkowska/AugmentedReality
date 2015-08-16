/*jslint sloppy:true, plusplus: true, sub: true, vars: true, white: true */
/*jshint sub:true */
/*global $, Math, calculateDirection, document, google, navigator, onDeviceReady, onGeoError, onGeoSuccess, parseInt, relativePosition, setupMap,  window */

var isCameraOn = false;

var apiUrl = 'http://skynote3.azurewebsites.net/api/';
 
var pin = [
    {"name":"New York", "lat":"40.714353", "lng":"-74.005973"},
    {"name":"San Francisco", "lat":"37.77493", "lng":"-122.419416"},
    {"name":"Seattle", "lat":"47.60621", "lng":"-122.332071"},
    {"name":"Los Angeles", "lat":"34.052234", "lng":"-118.243685"},
    {"name":"Denver", "lat":"39.737567", "lng":"-104.984718"},
    {"name":"Chicago", "lat":"41.878114", "lng":"-87.629798"},
    {"name":"Austin", "lat":"30.267153", "lng":"-97.743061"},
    {"name":"Miami", "lat":"25.788969", "lng":"-80.226439"},
    {"name":"Pittsburg", "lat":"40.440625", "lng":"-79.995886"},
    {"name":"Phoenix", "lat":"33.448377", "lng":"-112.074037"},
    {"name":"Atlanta", "lat":"33.748995", "lng":"-84.387982"},
    {"name":"Kansas City", "lat":"39.099727", "lng":"-94.578567"}
];        
var markersArray = [], bounds, map, watchGeoID, watchCompassID, watchAccelerometerID; 
var myLat = 0, myLng = 0; 
var bearing, distance;
var dataStatus = 0;    


// setup map and listen to deviceready        
$( document ).ready(function() {
    
    
    var $signupForm = $("#signupForm");
        $signupForm.submit(function (event) {
            event.preventDefault();
            debugger;
            if ($signupForm.valid()) {
                $.ajax({
                    url: apiUrl/*'http://localhost:56495/api/'*/+'user',
                    type: 'POST',
                    data: $signupForm.serializeArray(),
                    success: function (data) {
                        if (data.IsSuccess) {
                            debugger;
                            $("#success-message").html("OK").show();
                            $signupForm.hide();
                        } else {
                            $(".alert").html(data.ErrorsToString).show();
                        }
                    }
                });                
            }
        });
    
    // validate signup form on keyup and submit
		$signupForm.validate({
			rules: {
				firstname: "required",
				lastname: "required",
				username: {
					required: true,
					minlength: 2
				},
				password: {
					required: true,
                    pattern: /^(?=.*\d)(?=.*[a-zA-Z]).*$/,
                    minlength: 8,
                    maxlength: 16
				},
				confirm_password: {
					required: true,
					equalTo: "#password"
				},
				email: {
					required: true,
					email: true
				}
			},
			messages: {
				firstname: "Please enter your firstname",
				lastname: "Please enter your lastname",
				username: {
					required: "Please enter a username",
					minlength: "Your username must consist of at least 2 characters"
				},
				password: {
					required: "Please provide a password",
					pattern: "Password has to contain at least one letter and one digit",
                    minlength: "Your password must consist of at least 8 characters",
                    maxlength: "Your password must consist of max 16 characters"
				},
				confirm_password: {
					required: "Please provide a password",
					equalTo: "Please enter the same password as above"
				},
				email: "Please enter a valid email address"
			}
		});

    
    document.addEventListener("deviceready", onDeviceReady, false);
    
    WinJS.Application.onready = function () {
            
        
WinJS.UI.Pages.define("/pages/home.html", {

        // This function is called whenever a user navigates to this page. It
        // populates the page elements with the app's data.
        ready: function (element, options) {
           alert("page");

        }
    });
        
        
            // Define a Person 'class' with bindable properties.
    var Person = WinJS.Binding.define({
        name: "",
        color: "",
        birthday: "",
        petname: "",
        dessert: ""
    });

    // Declare an array of People objects.
    var people = [
        new Person({ name: "Bob", color: "red", birthday: "2/2/2002", petname: "Spot", dessert: "chocolate cake" }),
        new Person({ name: "Sally", color: "green", birthday: "3/3/2003", petname: "Xena", dessert: "cherry pie" }),
        new Person({ name: "Fred", color: "blue", birthday: "2/2/2002", petname: "Pablo", dessert: "ice cream" }),
    ];
        
        // Update the displayed data when the selector changes.
    function handleChange(evt) {
        var templateElement = document.querySelector("#templateDiv");
        var renderElement = document.querySelector("#templateControlRenderTarget");
        renderElement.innerHTML = "";

        var selected = evt.target.selectedIndex;
        var templateControl = templateElement.winControl;

       /* while (selected >= 0) {
            templateElement.winControl.render(people[selected--])
                .done(function (result) {
                    renderElement.appendChild(result);
                });        
        }
     */   
        while (selected >= 0) {
        templateElement.winControl.render(people[selected--], renderElement); 
    } 
    }
    
        
              // Add event handler to selector. 
            var selector = document.querySelector("#templateControlObjectSelector");
            selector.addEventListener("change", handleChange, false);
        
    // The next line will apply declarative control binding to all elements
    // (e.g. DIV with attribute: data-win-control="WinJS.UI.Rating")
        
        var person = { name: "Fran" };
     var personDiv = document.querySelector('#nameSpan');
    WinJS.Binding.processAll(personDiv, person);
   
        
WinJS.Namespace.define("Sample", {
    navBarInvoked: WinJS.UI.eventHandler(navBarInvoked)
});

WinJS.UI.processAll().done(function () {
    document.getElementById('createNavBar').winControl.open();
});

        
    WinJS.UI.processAll().then(function () {
    /*var control = document.getElementById("ratingControlHost").winControl;
    control.averageRating = 3; 
        control.addEventListener("change", ratingChanged, false); 
      */  
        
        var controlNav = document.getElementById("createNavBar").winControl;
        controlNav.addEventListener("navigated", onnavigatedFun, false); 
        
         var bindingSource = WinJS.Binding.as(person);
        
        document.querySelector("#btnGetName").onclick = function () {
            getName(bindingSource, nameArray);
    
    }
        
});
};

WinJS.Application.start();
    
    
    
});



var nameArray =
        new Array("Sally", "Jack", "Hal", "Heather", "Fred", "Paula", "Rick", "Megan", "Ann", "Sam");

function getName(source, nameArray) {
    source.name = nameArray[randomizeValue()];
}

function randomizeValue() {
    var value = Math.floor((Math.random() * 1000) % 8);
    if (value < 0)
        value = 0;
    else if (value > 9)
        value = 9;
    return value;
}

function ratingChanged(event) {

    var outputParagraph = document.getElementById("outputParagraph");
        var output = event.type + ": <ul>";
        var property;
        for (property in event) {
            output += "<li>" + property + ": " + event[property] + "</li>";
        }
 
       // outputParagraph.innerHTML = output + "</ul>";
    
}

function navBarInvoked(ev) {
    var navbarCommand = ev.detail.navbarCommand;
    log(navbarCommand.label + " NavBarCommand invoked<br/>");
    debugger;
    
        var contentHost = 
            document.body.querySelector("#contenthost"),
            url = navbarCommand.location;
 alert(url);
    
        // Remove existing content from the host element.
        WinJS.Utilities.empty(contentHost);

        // Display the new page in the content host.
        WinJS.UI.Pages.render(url, contentHost);
    
}

function log(msg) {
    var statusEl = document.getElementById("status");
    statusEl.innerHTML += msg;
    statusEl.scrollTop = statusEl.scrollHeight;
}

// start device compass, accelerometer and geolocation after deviceready        
function onDeviceReady() {
    if( window.Cordova && navigator.splashscreen ) {     // Cordova API detected
        navigator.splashscreen.hide() ;                 // hide splash screen
    }
  var json = { Id: 8, Content: 'test0909090' };
var commentsUrl = apiUrl+'comments';
  $.ajax({ 
  url: commentsUrl,//http://localhost:56495
  type: 'GET',
  success: function(data) {
      data.forEach(function(item){
      alert("get all: " +item.Content);
      });
        }
  });
    
      $.ajax({
  url: commentsUrl+'/5',
  type: 'GET',
  success: function(data) {
        alert("get one: " +data.Content);
        }
  });
    
      $.ajax({ 
  url: commentsUrl, 
  type: 'POST',
  data: json,
  success: function(data) {
        alert("post: " + data.Content);
        }
  });
    
      $.ajax({
  url: commentsUrl,
  type: 'PUT',
  data: json,
  success: function(data) {
        alert("put: " +data.Content);
        }
  });
    
    
    setupMap();
    // start cordova device sensors
    startAccelerometer();
    startCompass();
    startGeolocation(); 
}


// start intel.xdk augmented reality mode, adds camera in background       
function xdkStartAR(){
 //   alert("before start ar");
    intel.xdk.display.startAR(); 
    isCameraOn = true;
  //  alert("after start ar");
    $('#arView').css('background-color','transparent');
    $('body').css('background-color','transparent');
}
        
// stop intel.xdk augmented reality mode        
function xdkStopAR(){
    intel.xdk.display.stopAR(); 
    isCameraOn = false;
   //  alert("camera off");
    
}   

// setup google maps api        
function setupMap(){
    $("#map").height($(window).height()-60);
    var mapOptions = {
        zoom: 13,
        mapTypeControl: false,
        streetViewControl: false,
        navigationControl: true,
        scrollwheel: false,
        navigationControlOptions: {style: google.maps.NavigationControlStyle.SMALL},
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    map = new google.maps.Map(document.getElementById("map"), mapOptions);
}        
 
// toggle between list view and map view        
function toggleView(){
    if($(".listView").is(":visible")){
        $(".listView").hide();
        $("#map").height($(window).height()-60);
        $(".mapView").fadeIn(function(){google.maps.event.trigger(map, "resize");map.fitBounds(bounds);});
        $("#viewbtn").html("List");
    } else {
        $(".mapView").hide();
        $(".listView").fadeIn();
        $("#viewbtn").html("Map");
    }
}

// get data from API and store in array, add to list view and create markers on map, calculate         
function loadData(){
    dataStatus = "loading";
    markersArray = [];
    bounds = new google.maps.LatLngBounds();
    // add blue gps marker
    var icon = new google.maps.MarkerImage('http://www.google.com/intl/en_us/mapfiles/ms/micons/blue-dot.png',new google.maps.Size(30, 28),new google.maps.Point(0,0),new google.maps.Point(9, 28));
    var gpsMarker = new google.maps.Marker({position: new google.maps.LatLng(myLat, myLng), map: map, title: "My Position", icon:icon});
    bounds.extend(new google.maps.LatLng(myLat, myLng));
    markersArray.push(gpsMarker);
    // add all location markers to map and list view and array
    var i;
    for(i = 0; i < pin.length; i++){
        $(".listItems").append("<div class='item'>"+pin[i].name+"</div>");
        addMarker(i);
        relativePosition(i);
    }
    map.fitBounds(bounds);
    google.maps.event.trigger(map, "resize");
    dataStatus = "loaded";   
}

// add marker to map and in array        
function addMarker(i){
    var marker = new google.maps.Marker({position: new google.maps.LatLng(pin[i].lat, pin[i].lng), map: map, title: pin[i].name});
    bounds.extend(new google.maps.LatLng(pin[i].lat, pin[i].lng));
    markersArray.push(marker);
} 

// clear all markers from map and array        
function clearMarkers() {
    'use strict';
    while (markersArray.length) {
        markersArray.pop().setMap(null);
    }
}        

// calulate distance and bearing value for each of the points wrt gps lat/lng        
function relativePosition(i){
    var pinLat = pin[i].lat;
    var pinLng = pin[i].lng;
    var dLat = (myLat-pinLat)* Math.PI / 180;
    var dLon = (myLng-pinLng)* Math.PI / 180;
    var lat1 = pinLat * Math.PI / 180;
    var lat2 = myLat * Math.PI / 180;
    var y = Math.sin(dLon) * Math.cos(lat2);
    var x = Math.cos(lat1)*Math.sin(lat2) - Math.sin(lat1)*Math.cos(lat2)*Math.cos(dLon);
    bearing = Math.atan2(y, x) * 180 / Math.PI;
    bearing = bearing + 180;
    pin[i]['bearing'] = bearing;

    var a = Math.sin(dLat/2) * Math.sin(dLat/2) + Math.sin(dLon/2) * Math.sin(dLon/2) * Math.cos(lat1) * Math.cos(lat2); 
    var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1-a)); 
    distance = 3958.76  * c;
    pin[i]['distance'] = distance;
}

// calculate direction of points and display        
function calculateDirection(degree){
    var detected = 0;
    $("#spot").html("");
    var i;
    for(i = 0;i < pin.length; i++){
        if(Math.abs(pin[i].bearing - degree) <= 20){
            var away, fontSize, fontColor;
            // varry font size based on distance from gps location
            if(pin[i].distance>1500){
                away = Math.round(pin[i].distance);
                fontSize = "16";
                fontColor = "#ccc";
            } else if(pin[i].distance>500){
                away = Math.round(pin[i].distance);
                fontSize = "24";
                fontColor = "#ddd";
            } else {
                away = pin[i].distance.toFixed(2);
                fontSize = "30";
                fontColor = "#eee";
            }
            $("#spot").append('<div class="name" data-id="'+i+'" style="margin-left:'+(((pin[i].bearing - degree) * 5)+50)+'px;width:'+($(window).width()-100)+'px;font-size:'+fontSize+'px;color:'+fontColor+'">'+pin[i].name+'<div class="distance">'+ away +' miles away</div></div>');
            detected = 1;
        } else {
            if(!detected){
                $("#spot").html("");
            }
        }
    }

} 




function success(pos) {
  var crd = pos.coords;

  alert('Your current position is:');
  alert('Latitude : ' + crd.latitude);
  alert('Longitude: ' + crd.longitude);
  alert('More or less ' + crd.accuracy + ' meters.');
};

function error(err) {
  alert('ERROR(' + err.code + '): ' + err.message);
};


// Start watching the geolocation        
function startGeolocation(){
   // var options = { timeout: 30000 };
    var options = {
  enableHighAccuracy: true,
  timeout: 15000,
  maximumAge: 90000
};
    watchGeoID = navigator.geolocation.watchPosition(onGeoSuccess, onGeoError, options);    
}

// Stop watching the geolocation
function stopGeolocation() {
    if (watchGeoID) {
        navigator.geolocation.clearWatch(watchGeoID);
        watchGeoID = null;
    }
}

// onSuccess: Get the current location
function onGeoSuccess(position) {
    'use strict';
    document.getElementById('geolocation').innerHTML = 'Latitude: ' + position.coords.latitude + '<br />' + 'Longitude: ' + position.coords.longitude;
    myLat = position.coords.latitude;
    myLng = position.coords.longitude;
    if(!dataStatus){
        loadData();
    }
}

// onError: Failed to get the location
function onGeoError() {
    
    document.getElementById('log').innerHTML += "onError=.";
} 

// Start watching the compass
function startCompass() {
    var options = { frequency: 100 };
    watchCompassID = navigator.compass.watchHeading(onCompassSuccess, onCompassError, options);
}

// Stop watching the compass
function stopCompass() {
    if (watchCompassID) {
        navigator.compass.clearWatch(watchCompassID);
        watchCompassID = null;
    }
}

// onSuccess: Get the current heading
function onCompassSuccess(heading) {
    var directions = ['N', 'NE', 'E', 'SE', 'S', 'SW', 'W', 'NW', 'N'];
    var direction = directions[Math.abs(parseInt((heading.magneticHeading) / 45) + 0)];
    document.getElementById('compass').innerHTML = heading.magneticHeading + "<br>" + direction;
    document.getElementById('direction').innerHTML = direction;
    var degree = heading.magneticHeading;
    if($("#arView").is(":visible") && dataStatus != "loading"){
        calculateDirection(degree);
    }
}

// onError: Failed to get the heading
function onCompassError(compassError) {
    document.getElementById('log').innerHTML += "onError=."+compassError.code;
}        

// Start checking the accelerometer
function startAccelerometer() {
    var options = { frequency: 1000 }; 
    watchAccelerometerID = navigator.accelerometer.watchAcceleration(onAccelerometerSuccess, onAccelerometerError, options);
}

// Stop checking the accelerometer
function stopAccelerometer() {
    if (watchAccelerometerID) { 
        navigator.accelerometer.clearWatch(watchAccelerometerID);
        watchAccelerometerID = null;
    }
}

// onSuccess: Get current accelerometer values
function onAccelerometerSuccess(acceleration) {
    // for debug purpose to print out accelerometer values
    var element = document.getElementById('accelerometer');
    element.innerHTML = 'Acceleration X: ' + acceleration.x + '<br />' +
                        'Acceleration Y: ' + acceleration.y + '<br />' +
                        'Acceleration Z: ' + acceleration.z ;
    if(acceleration.y > 7 ){//&& !isCameraOn){
        $("#arView").fadeIn();
        $("#topView").hide();
        document.getElementById('body').style.background = "#d22";
        xdkStartAR();
    } else {
        //alert("ac: "+acceleration.y + " cam: " + isCameraOn);
        $("#arView").hide();
        $("#topView").fadeIn();
        document.getElementById('body').style.background = "#fff";
        xdkStopAR();
    }
}

// onError: Failed to get the acceleration
function onAccelerometerError() {
    document.getElementById('log').innerHTML += "onError.";
}

function onnavigatedFun(evt) {
    alert("nav");
        var contentHost = 
            document.body.querySelector("#contenthost"),
            url = evt.detail.location;

        // Remove existing content from the host element.
        WinJS.Utilities.empty(contentHost);

        // Display the new page in the content host.
        WinJS.UI.Pages.render(url, contentHost);
    }
