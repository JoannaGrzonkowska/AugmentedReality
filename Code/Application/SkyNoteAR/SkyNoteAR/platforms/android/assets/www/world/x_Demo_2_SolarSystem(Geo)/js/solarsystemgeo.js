var Solar = {
    planetsInfo: null,

    init: function() {
        var distanceFactor = 580.2;

        /* null means: use relative to user, sun is NORTH to the user */
        var locationSun = new AR.RelativeLocation(null, 25000, 0, 5000);
        var noteLocation1 = new AR.GeoLocation(54.371184, 18.613910);
        var noteLocation2 = new AR.GeoLocation(54.370947, 18.614214);

        /* sizes & distances are far away from real values! used these scalings to be able to show within user range */
        var sizeFactor = 0.5;
        var sizeEarth = 12.8 * 25;

        /* every object in space has a name, location and a circle (drawable) */
        var noteImg = new AR.ImageResource("assets/note-icon.png");
       

        var sunSize = (((109 * sizeEarth) / sizeEarth) * 0.3) * sizeFactor;
        var mercurySize = (4.9 * sizeEarth / sizeEarth) * sizeFactor;
        var venusSize = (12.0 * sizeEarth / sizeEarth) * sizeFactor;
        var earthSize = (10 * sizeEarth / sizeEarth) * sizeFactor;
        var marsSize = (6.8 * sizeEarth / sizeEarth) * sizeFactor;
        var jupiterSize = (14.4 * sizeEarth / sizeEarth) * sizeFactor;
        var saturnSize = (12.0 * sizeEarth / sizeEarth) * sizeFactor;
        var uranusSize = (5.20 * sizeEarth / sizeEarth) * sizeFactor;
        var neptunSize = (5.0 * sizeEarth / sizeEarth) * sizeFactor;
        var plutoSize = (0.23 * sizeEarth / sizeEarth) * sizeFactor;

        var sun = {
            name: "Sun",
            distance: 0,
            location: noteLocation1,
            imgDrawable: new AR.ImageDrawable(noteImg, sunSize),
            size: sunSize,
            description: "cos tam."
        };

        var mercury = {
            name: "Mercury",
            distance: 3.9 * distanceFactor,
            location: new AR.RelativeLocation(noteLocation1, 0, 0, 2),
            imgDrawable: new AR.ImageDrawable(noteImg, mercurySize),
            size: mercurySize,
            description: "Jakis tekst"
        };

        var venus = {
            name: "Venus",
            distance: 7.2 * distanceFactor,
            location: new AR.RelativeLocation(noteLocation1, 2, 0, 0),
            imgDrawable: new AR.ImageDrawable(noteImg, venusSize),
            size: venusSize,
            description: "Notatka"
        };

        var earth = {
            name: "Earth",
            distance: 10 * distanceFactor,
            location: new AR.RelativeLocation(noteLocation1, 0, 2, 0),
            imgDrawable: new AR.ImageDrawable(noteImg, earthSize),
            size: earthSize,
            description: "To nie ziemia. to notatka"
        };

        var mars = {
            name: "Mars",
            distance: 15 * distanceFactor,
            location: new AR.RelativeLocation(noteLocation1, 0, -2, 0),
            imgDrawable: new AR.ImageDrawable(noteImg, marsSize),
            size: marsSize,
            description: "Bleble "
        };

        var jupiter = {
            name: "Jupiter",
            distance: 50.2 * distanceFactor * 0.35,
            location: new AR.RelativeLocation(noteLocation2, 0, 0, 4),
            imgDrawable: new AR.ImageDrawable(noteImg, jupiterSize),
            size: jupiterSize,
            description: "Kolejna"
        };

        var saturn = {
            name: "Saturn",
            distance: 95.3 * distanceFactor * 0.2,
            location: noteLocation2,
            imgDrawable: new AR.ImageDrawable(noteImg, saturnSize),
            size: saturnSize,
            description: "jeszcze jedna"
        };

        var uranus = {
            name: "Uranus",
            distance: 192 * distanceFactor * 0.1,
            location: new AR.RelativeLocation(noteLocation2, 2, 1, 0),
            imgDrawable: new AR.ImageDrawable(noteImg, uranusSize),
            size: uranusSize,
            description: "Notatka Szymon"
        };

        var neptun = {
            name: "Neptune",
            distance: 301 * distanceFactor * 0.07,
            location: new AR.RelativeLocation(noteLocation1, 0, 3, 0),
            imgDrawable: new AR.ImageDrawable(noteImg, neptunSize),
            size: neptunSize,
            description: "Notatka Asia"
        };

        var pluto = {
            name: "Pluto",
            distance: 394 * distanceFactor * 0.063,
            location: new AR.RelativeLocation(noteLocation1, -2, -2, 0),
            imgDrawable: new AR.ImageDrawable(noteImg, plutoSize),
            size: plutoSize,
            description: "Notatka Kasia"
        };


        /* put sun, planets (and pluto) in an array */
        this.planetsInfo = [sun, mercury, venus, earth, mars, jupiter, saturn, uranus, neptun, pluto];

        /* create helper array to create goeObjects out of given information */
        var planetsGeoObjects = [];
        for (var i = 0; i < this.planetsInfo.length; i++) {

            /* show name of object below*/
            var label = new AR.Label(this.planetsInfo[i].name, 3, {
                offsetY: -this.planetsInfo[i].size / 2,
                verticalAnchor: AR.CONST.VERTICAL_ANCHOR.TOP,
                opacity: 0.9,
                zOrder: 1,
                style: {
                    textColor: '#FFFFFF',
                    backgroundColor: '#00000005'
                }
            });

            /* drawable in cam of object -> image and label */
            var drawables = [];
            drawables[0] = this.planetsInfo[i].imgDrawable;
            drawables[1] = label;

            /* Create objects in AR*/
            planetsGeoObjects[i] = new AR.GeoObject(this.planetsInfo[i].location, {
                drawables: {
                    cam: drawables
                },
                onClick: this.planetClicked(this.planetsInfo[i])
            });
           
        }

        // Add indicator to sun
        var imageDrawable = new AR.ImageDrawable(indicatorImg, 0.1, {
            verticalAnchor: AR.CONST.VERTICAL_ANCHOR.TOP
        });
        planetsGeoObjects[0].drawables.addIndicatorDrawable(imageDrawable);
    },     

    planetClicked: function(planet) {
        return function() {
            document.getElementById("info").setAttribute("class", "info");
            document.getElementById("name").innerHTML = planet.name;
            document.getElementById("info").setAttribute("class", "infoVisible");
        };
    }
};

Solar.init();