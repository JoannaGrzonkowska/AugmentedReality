var CropBoxHelper = function (imagePathParam, div, onCropFunc) {
   
    var self = this;
    self.imagePath = ko.observable(imagePathParam);

    var options =
                {
                    imageBox: '.image-box',
                    thumbBox: '.thumbBox',
                    spinner: '.spinner',
                    imgSrc: self.imagePath()
                };

    var imageBox = div.find('.imageBox');
    var cropper = imageBox.cropbox(options);

    div.find('#file').on('change', function () {
        var reader = new FileReader();
        reader.onload = function (e) {
            options.imgSrc = e.target.result;
            cropper = imageBox.cropbox(options);
        }
        reader.readAsDataURL(this.files[0]);
        this.files = [];
    });

    function onPhotoDataSuccess(imageData) {
        options.imgSrc = "data:image/jpeg;base64," + imageData;
        cropper = imageBox.cropbox(options);
    };

    function onFail(message) {
        alert('Failed because: ' + message);
    };

    div.find('#btnPhoto').on('click', function(){
        navigator.camera.getPicture(onPhotoDataSuccess, onFail, {
            quality: 50,
            targetWidth: 512,
            targetHeight: 512,
            destinationType: navigator.camera.DestinationType.DATA_URL
        });
    });

    div.find('#btnCrop').on('click', function(){
        var img = cropper.getDataURL();
        onCropFunc(img)
    });

    div.find('#btnZoomIn').on('click', function(){
        cropper.zoomIn();
    });

    div.find('#btnZoomOut').on('click', function(){
        cropper.zoomOut();
    });
};